using System.Linq;
using CzechCases.Model;

namespace CzechCases.UnitTests
{
    public static class WordEqualityComparer
    {
        public static bool Equals(Word x, Word y)
        {
            var xSing = x.WordCases.Singular;
            var xPlur = x.WordCases.Plural;
            var ySing = y.WordCases.Singular;
            var yPlur = y.WordCases.Plural;
            return (x.Gender == y.Gender &&
                    CompareCases(xSing, ySing) &&
                    CompareCases(xPlur, yPlur));
        }

        private static bool CompareCases(WordCases x, WordCases y)
        {
           return CompareCase(x.Nominativ, y.Nominativ) &&
                CompareCase(x.Genitiv, y.Genitiv) &&
                CompareCase(x.Dativ, y.Dativ) &&
                CompareCase(x.Akuzativ, y.Akuzativ) &&
                CompareCase(x.Vokativ, y.Vokativ) &&
                CompareCase(x.Lokal, y.Lokal) &&
                CompareCase(x.Instrumental, y.Instrumental);
        }

        private static bool CompareCase(string[] xCaseStrings, string[] yCaseStrings)
        {
            return xCaseStrings.SequenceEqual(yCaseStrings);
        }
    }
}