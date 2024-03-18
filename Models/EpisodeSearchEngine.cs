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
            _writer.AddDocument(document);
        }
        _writer.Commit();
    }

    public IEnumerable<Episode> Search(string searchTerm)
    {

        var directoryReader = DirectoryReader.Open(_directory);
        var searcher = new IndexSearcher(directoryReader);
        string[] fields = { "Title", "EpisodeNumber", "Summary", "Link", "Transcript" };
        var queryParser = new MultiFieldQueryParser(version, fields, _analyzer);
        var query = queryParser.Parse(searchTerm);
        var hits = searcher.Search(query, 10).ScoreDocs;
        var episodes = new List<Episode>();
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
            episodes.Add(episode);
        }
        return episodes;
    }


}