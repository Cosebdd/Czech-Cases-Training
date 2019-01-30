using System;
using System.IO;
using System.Text;
using CzechCases.Wiktionary;

namespace CzechCases.Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder strBuilder = new StringBuilder();
            JsonBatchAllNouns batcher = new JsonBatchAllNouns(500);
            WordPutter putter = new WordPutter();
            using (WordQuerier querier = new WordQuerier())
            {
                foreach (var batch in batcher.GetBathces())
                {
                    foreach (var s in batch)
                    {
                        var wordIsExtracted = querier.TryQueryWord(s, out var word);
                        if (s.Length < 3 || char.IsUpper(s[0]) || !wordIsExtracted)
                            continue;
                        var puttedWord = putter.Create(WordConverter.ConvertWord(word)).Result;
                        Console.WriteLine(puttedWord.WordCases.Singular.Nominativ[0]);
                    }
                }
            }
        }
    }
}
