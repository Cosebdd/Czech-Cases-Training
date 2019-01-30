using System;
using CzechCases.Model;
using DbWord = CzechCases.Database.Model.Word;
using DBAllCases = CzechCases.Database.Model.WordAllCases;
using DBCases = CzechCases.Database.Model.WordCases;
using DBGender = CzechCases.Database.Model.GrammaticalGender;

namespace CzechCases.Aggregator
{
    internal static class WordConverter
    {
        public static DbWord ConvertWord(Word word)
        {
            return new DbWord()
            {
                Gender = (DBGender)word.Gender,
                WordCases = ConvertAllCases(word.WordCases)
            };
        }

        private static DBAllCases ConvertAllCases(WordAllCases cases)
        {
            return new DBAllCases()
            {
                Singular = ConvertCases(cases.Singular),
                Plural = ConvertCases(cases.Plural)
            };
        }


        private static DBCases ConvertCases(WordCases cases)
        {
            return new DBCases()
            {
                Nominativ = cases.Nominativ,
                Akuzativ = cases.Akuzativ,
                Dativ = cases.Dativ,
                Genitiv = cases.Genitiv,
                Instrumental = cases.Instrumental,
                Lokal = cases.Lokal,
                Vokativ = cases.Vokativ
            };
        }


    }
}