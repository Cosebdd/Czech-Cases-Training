using System;
using System.Text.RegularExpressions;
using CzechCases.Model;

namespace CzechCases.Wiktionary.Parsing
{
    public static class WikiContentParser
    {
        private const string CzechPartRegExp = @"== čeština ==[\s\S]+?\n== |$";
        private const string CasesPartRegExp = @"==== skloňování ====[\s\S]+?\n=|$";
        private const string GenderPartRegExp = @"=== podstatné jméno ===[\s\S]+?\n=|$";

        public static bool TryParseWikiContent(string pageConent, out Word word)
        {
            pageConent = pageConent.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "");
            pageConent = Regex.Replace(pageConent, @"\(.+?\)", "");
            pageConent = Regex.Replace(pageConent, @"[ ]{2,}", " ");
            word = null;
            if (!TryGetCzechPart(pageConent, out var czechPart) 
                || !TryGetGenderPart(czechPart, out var genderPart) 
                || !TryGetCasesPart(czechPart, out var casesPart) 
                || !GrammaticalGenderParser.TryParseGrammaticalGender(genderPart, out var gender) 
                || !WordCasesParser.TryParseWordCases(casesPart, out var cases))
                return false;

            word = new Word(cases, gender);
            return true;
        }

        private static bool TryGetCzechPart(string pageContent, out string czechPart)
        {
            return TryReturnFirstMatchedResult(pageContent, CzechPartRegExp, out czechPart);
        }

        private static bool TryGetGenderPart(string czechPart, out string genderPart)
        {
            return TryReturnFirstMatchedResult(czechPart, GenderPartRegExp, out genderPart);
        }

        private static bool TryGetCasesPart(string czechPart, out string casesPart)
        {
            return TryReturnFirstMatchedResult(czechPart, CasesPartRegExp, out casesPart);
        }

        private static bool TryReturnFirstMatchedResult(string input, string regexp, out string result)
        {
            result = null;
            var matchResult = Regex.Match(input, regexp, RegexOptions.Singleline);
            if (!matchResult.Success || matchResult.Captures.Count == 0 || String.IsNullOrWhiteSpace(matchResult.Captures[0].Value))
                return false;
            result = matchResult.Captures[0].Value;
            return true;
        }
    }
}
