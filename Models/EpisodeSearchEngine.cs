using System.Reflection.Metadata;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using System.Diagnostics;
using LuceneDirectory = Lucene.Net.Store.Directory;
using OpenMode = Lucene.Net.Index.OpenMode;
using Document = Lucene.Net.Documents.Document;
using Lucene.Net.QueryParsers.Classic;

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
        _writer = new IndexWriter(_directory, new IndexWriterConfig(version, _analyzer));

    }

    public void AddEpisodesToIndex(IEnumerable<Episode> episodes)
    {
        Console.WriteLine("Adding episodes to index");
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
            Console.WriteLine(document.Get("Title"));
            Console.WriteLine("Document created");
            _writer.AddDocument(document);
        }
        _writer.Commit();
    }

    public IEnumerable<Episode> Search(string searchTerm)
    {
        Console.WriteLine("Searching for: " + searchTerm);

        var directoryReader = DirectoryReader.Open(_directory);
        Console.WriteLine("Directory reader opened");
        var searcher = new IndexSearcher(directoryReader);
        Console.WriteLine("Index searcher created");
        string[] fields = { "Title", "EpisodeNumber", "Summary", "Link", "Transcript" };
        Console.WriteLine("Fields created");
        var queryParser = new MultiFieldQueryParser(version, fields, _analyzer);
        Console.WriteLine("Query parser created");
        var query = queryParser.Parse(searchTerm);
        Console.WriteLine("Query created");
        var hits = searcher.Search(query, 10).ScoreDocs;
        Console.WriteLine("Hits found: " + hits.Length);
        var episodes = new List<Episode>();
        Console.WriteLine("Episodes list created");
        foreach (var hit in hits)
        {
            var foundDoc = searcher.Doc(hit.Doc);
            var episode = new Episode
            {
                Id = int.Parse(foundDoc.Get("Id")),
                Title = foundDoc.Get("Title"),
                EpisodeNumber = foundDoc.Get("EpisodeNumber"),
                Summary = foundDoc.Get("Summary"),
                Link = foundDoc.Get("Link"),
                Transcript = foundDoc.Get("Transcript")
            };

            Console.WriteLine("Episode found: \n");
            Console.WriteLine(episode.Title);
            Console.WriteLine(episode.Summary);
            episodes.Add(episode);
        }
        Console.WriteLine("Episodes found: " + episodes.Count);
        return episodes;
    }


}