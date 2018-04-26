using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace CzechCases.Wiktionary
{
    public class JsonBatchAllNouns
    {
        private readonly WiktionaryQueryBuilder _query;
        private ContinuationData _continue;

        public JsonBatchAllNouns(int portionSize)
        {
            _query = new WiktionaryQueryBuilder()
            .AddQuery("action=query")
            .AddQuery("format=json")
            .AddQuery("list=categorymembers")
            .AddQuery("cmtitle=Kategorie:%C4%8Cesk%C3%A1_substantiva")
            .AddQuery("cmprop=title")
            .AddQuery($"cmlimit={portionSize}");
        }

        public IEnumerable<string[]> GetBathces()
        {
            using (var webClient = new WebClient())
            {
                do
                {
                    var query = _continue == null ? _query.ToString() : _query.Copy().AddQuery($"cmcontinue={_continue.CmContinue}").ToString();
                    var response = webClient.DownloadString(query);
                    yield return ParseResponse(response);
                } while (_continue != null);
            }
        }

        private string[] ParseResponse(string response)
        {
            var result = JsonConvert.DeserializeObject<BatchResult>(response);
            _continue = result.Continue;
            return result.Query.CategoryMembers.Select(m => m.Title).ToArray();
        }

        private class ContinuationData
        {
            public string CmContinue { get; set; }
            public string Continue { get; set; }
        }

        private class BatchResult
        {
            public string Batchcomplete { get; set; }

            public ContinuationData Continue { get; set; }

            public QueryResult Query { get; set; }
            
            public class QueryResult
            {
                public CategoryMember[] CategoryMembers { get; set; }
            }

            public class CategoryMember
            {
                public int Ns { get; set; }
                public string Title { get; set; }
            }
        }
    }
}