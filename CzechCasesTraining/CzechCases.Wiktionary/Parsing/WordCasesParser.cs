using System;
using System.Linq;
using System.Text.RegularExpressions;
using CzechCases.Model;

namespace CzechCases.Wiktionary.Parsing
{
    internal class WordCasesParser
    {
        public static bool TryParseWordCases(string casesPart, out WordAllCases wordAllCases)
        {
            wordAllCases = null;
            if (!TryExtractCase(casesPart, "snom", out var snom) || 
                !TryExtractCase(casesPart, "sgen", out var sgen) ||
                !TryExtractCase(casesPart, "sdat", out var sdat) || 
                !TryExtractCase(casesPart, "sacc", out var sacc) ||
                !TryExtractCase(casesPart, "svoc", out var svoc) || 
                !TryExtractCase(casesPart, "sloc", out var sloc) ||
                !TryExtractCase(casesPart, "sins", out var sins) || 
                !TryExtractCase(casesPart, "pnom", out var pnom) ||
                !TryExtractCase(casesPart, "pgen", out var pgen) || 
                !TryExtractCase(casesPart, "pdat", out var pdat) ||
                !TryExtractCase(casesPart, "pacc", out var pacc) || 
                !TryExtractCase(casesPart, "pvoc", out var pvoc) ||
                !TryExtractCase(casesPart, "ploc", out var ploc) ||
                !TryExtractCase(casesPart, "pins", out var pins))
                return false;

            var singleCases = new WordCases(snom, sgen, sdat, sacc, svoc, sloc, sins);
            var pluralCases = new WordCases(pnom, pgen, pdat, pacc, pvoc, ploc, pins);

            wordAllCases = new WordAllCases(singleCases, pluralCases);

            return true;
        }

        private static bool TryExtractCase(string text, string caseString, out string[] words)
        {
            words = null;
            var match = Regex.Match(text, caseString + " = (.+)", RegexOptions.Multiline);

            if (match.Groups.Count < 2 || string.IsNullOrWhiteSpace(match.Captures[0].Value))
                return false;

            words = match.Groups[1].Value.Split('/').Select(s => s.Trim()).ToArray();
            return true;

        }
    }
}