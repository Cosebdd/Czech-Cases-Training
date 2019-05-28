using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CzechCases.Model;
using CzechCases.Wiktionary.Parsing;
using Newtonsoft.Json.Linq;

namespace CzechCases.Wiktionary
{
    public class WordQuerier : IDisposable
    {
        private readonly WebClient _client;

        public WordQuerier()
        {
            _client = new WebClient();
        }

        public async Task<Word> QueryWordAsync(string word)
        {
            var query = BuildQuery(word);
            var pageContentJson = await _client.DownloadStringTaskAsync(query.ToString());

            var pageContent = GetPageContent(pageContentJson);
            Console.WriteLine($"Parsing {word}");
            return await WikiContentParser.ParseWikiContentAsync(pageContent);
        }

        private WiktionaryQueryBuilder BuildQuery(string word)
        {
            return new WiktionaryQueryBuilder().
                AddQuery("format=json").
                AddQuery("action=query").
                AddQuery("prop=revisions").
                AddQuery("rvprop=content").
                AddQuery("titles=" + word);
        }

        private string GetPageContent(string jsonContent)
        {
            var pages = JObject.Parse(jsonContent)["query"]["pages"].Value<JObject>();
            var pageRevisions = pages.PropertyValues().First()["revisions"].Values<JObject>();
            var pageContent = pageRevisions.First()["*"];

            return pageContent.ToString();
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}