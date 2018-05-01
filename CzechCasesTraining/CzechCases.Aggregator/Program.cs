﻿using System;
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
            using (WordQuerier querier = new WordQuerier())
            {
                foreach (var bathce in batcher.GetBathces())
                {
                    foreach (var s in bathce)
                    {
                        if (s.Length < 3 || char.IsUpper(s[0]) || !querier.TryQueryWord(s, out var _))
                            continue;
                        Console.WriteLine(s);
                        strBuilder.AppendLine(s);
                    }
                }
            }

            File.WriteAllText(@".\CzechAllWords.txt", strBuilder.ToString(), Encoding.Unicode);
        }
    }
}