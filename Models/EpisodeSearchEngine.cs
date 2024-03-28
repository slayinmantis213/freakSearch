// using System.Reflection.Metadata;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Search;
// using System.Diagnostics;
// using LuceneDirectory = Lucene.Net.Store.Directory;
// using OpenMode = Lucene.Net.Index.OpenMode;
using Document = Lucene.Net.Documents.Document;
using Lucene.Net.QueryParsers.Classic;
// using Lucene.Net.Analysis.En;
using Lucene.Net.Search.Spell;
using Lucene.Net.Search.Highlight;

namespace freakSearch.Models;

public class EpisodeSearchEngine
{
    private const LuceneVersion version = LuceneVersion.LUCENE_48;
    private readonly StandardAnalyzer _analyzer;
    private readonly RAMDirectory _directory;
    private readonly IndexWriter _writer;

    public EpisodeSearchEngine()
    {
        _analyzer = new StandardAnalyzer(version);
        // FS Directory path is likely just the path where the index is stored
        _directory = new RAMDirectory();
        var config = new IndexWriterConfig(version, _analyzer);
        _writer = new IndexWriter(_directory, config);
    }

    public void AddEpisodesToIndex(IEnumerable<Episode> episodes)
    {
        foreach (var episode in episodes)
        {
            var document = new Document
            {
                new StringField("Id", episode.Id.ToString(), Field.Store.YES),
                new TextField("Title", episode.Title, Field.Store.YES),
                new TextField("EpisodeNumber", episode.EpisodeNumber, Field.Store.YES),
                new TextField("Summary", episode.Summary, Field.Store.YES),
                new TextField("Link", episode.Link, Field.Store.YES),
                new TextField("Transcript", episode.Transcript, Field.Store.YES)
            };
            _writer.AddDocument(document);
        }
        _writer.Commit();
        _writer.Dispose();
    }

    public IEnumerable<Episode> Search(string searchTerm)
    {
        // use initial user search term to populate hits
        var directoryReader = DirectoryReader.Open(_directory);
        IndexSearcher searcher = new(directoryReader);
        string[] fields = { "Title", "EpisodeNumber", "Summary", "Link", "Transcript" };
        MultiFieldQueryParser queryParser = new(version, fields, _analyzer);
        var query = queryParser.Parse(searchTerm);
        Console.WriteLine($"searchTerm: {searchTerm}");
        // Console.WriteLine($"query: {query}");
        var hits = searcher.Search(query, 10).ScoreDocs;

        // spell check if no hits
        if(hits.Length < 1)
        {
            SpellChecker spellChecker = new(_directory);
            IndexWriterConfig config = new(version, _analyzer);
            spellChecker.IndexDictionary(new LuceneDictionary(directoryReader, "Transcript"), config, true); // Indexing transcripts for spell checking
            // bool termExists = spellChecker.Exist(searchTerm);
            string[] suggestedTerms = spellChecker.SuggestSimilar(searchTerm, 2);
            if (suggestedTerms.Length > 0)
            {
                foreach (string suggestion in suggestedTerms)
                {
                    Console.WriteLine("Did you mean: " + suggestion);
                }
                searchTerm = suggestedTerms[0];
                Console.WriteLine("SEARCH TERM 'CORRECTED'");
            }
        }
        query = queryParser.Parse(searchTerm);
        hits = searcher.Search(query, 10).ScoreDocs;
        //instantiate highlighter stuff
        SimpleHTMLFormatter htmlFormatter = new();
        Highlighter highlighter = new(htmlFormatter, new QueryScorer(query));

        //populate episode list
        var episodes = new List<Episode>();
        foreach (var hit in hits)
        {
            int id = hit.Doc;
            var foundDoc = searcher.Doc(id);
            var episode = new Episode
            {
                Id = int.Parse(foundDoc.Get("Id")),
                Title = foundDoc.Get("Title"),
                EpisodeNumber = foundDoc.Get("EpisodeNumber"),
                Summary = foundDoc.Get("Summary"),
                Link = foundDoc.Get("Link"),
                Transcript = foundDoc.Get("Transcript")
            };
            if (searchTerm != "replay" && episode.Title.Contains("(Replay)")) continue;
            //inital obvious negative impact: reduces the number of results by the number of replays in the result, so if you search "replay" you get zero results.  
            //maybe we could populate more results as a padding for this? idea: increase collected hits to 20-30ish (ln 83) and then have an iterator in the hits loop that counts up when we .Add() to episodes.  When i == 10, break loop and display results

            //populate highlighter fragments for episode
            TokenStream tokenStream = TokenSources.GetAnyTokenStream(searcher.IndexReader, id, "Transcript", _analyzer);
            TextFragment[] frag = highlighter.GetBestTextFragments(tokenStream, episode.Transcript, mergeContiguousFragments: false, maxNumFragments: 10);
            string fragmentString = "";
            foreach (var f in frag)
            {
                if (f != null && f.Score > 0)
                {
                    fragmentString += f.ToString();
                    break;
                }
            }
            Console.WriteLine("frag: " + fragmentString);
            episode.Highlight = fragmentString;


            Console.WriteLine("ep id: " + episode.Id + ", ep title: " + episode.Title + ", ep num: " + episode.EpisodeNumber);
            episodes.Add(episode);
            Console.WriteLine("added ep");
        }
        Console.WriteLine("eps for display: " + episodes.Count);
        return episodes;
    }


}
