using System;

namespace CzechCases.Wiktionary
{
    public class WiktionaryQueryBuilder
    {
        private string _baseUrl = @"cs.wiktionary.org/w/api.php";

        private WiktionaryQueryBuilder(string query)
        {
            _baseUrl = query;
        }

        public WiktionaryQueryBuilder()
        {
            
        }

        public WiktionaryQueryBuilder AddQuery(string query)
        {
            var url = new UriBuilder(_baseUrl);
            var isQuery = url.Query != "";

            if (isQuery)
            {
                _baseUrl = url.Uri + "&" + query;
                url = new UriBuilder(_baseUrl);
            }
            else
                url.Query = query;

            _baseUrl = url.Uri.ToString();
            return this;
        }

        public WiktionaryQueryBuilder Copy()
        {
            return new WiktionaryQueryBuilder(_baseUrl);
        }

        public override string ToString()
        {
            return _baseUrl;
        }
    }
}