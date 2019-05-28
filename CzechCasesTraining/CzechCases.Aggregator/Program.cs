using System;using System.Linq;
using System.Threading.Tasks;
using CzechCases.Wiktionary;

namespace CzechCases.Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonBatchAllNouns batcher = new JsonBatchAllNouns(500);
            WordPutter putter = new WordPutter();
            using (WordQuerier querier = new WordQuerier())
            {
                var words = Task.WhenAll(batcher.GetBathces().SelectMany(b => b)
                    .Where(w => WordIsNotTooShort(w) && WordIsNotName(w)).Select(async w => await querier.QueryWordAsync(w)).Where(w => w != null).
                    Select(async w => await putter.Create(WordConverter.ConvertWord(w.Result)))).Result;
            }
        }

        private static bool WordIsNotTooShort(string word)
        {
            return word.Length >= 3;
        }

        private static bool WordIsNotName(string word)
        {
            return !char.IsUpper(word[0]);
        }
    }
}
