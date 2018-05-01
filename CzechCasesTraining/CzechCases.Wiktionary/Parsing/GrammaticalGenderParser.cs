using System.Collections.Generic;
using CzechCases.Model;

namespace CzechCases.Wiktionary.Parsing
{
    internal static class GrammaticalGenderParser
    {
        private static readonly IDictionary<string, GrammaticalGender> Genders = new Dictionary<string, GrammaticalGender>()
        {
            {"střední", GrammaticalGender.Neutral},
            {"mužský životný", GrammaticalGender.MaleAnimate},
            {"mužský neživotný", GrammaticalGender.MaleInanimate},
            {"ženský", GrammaticalGender.Female}
        };

        public static bool TryParseGrammaticalGender(string genderPart, out GrammaticalGender gender)
        {
            gender = GrammaticalGender.Unknown;
            foreach (var genderKey in Genders.Keys)
            {
                if (!genderPart.Contains(genderKey)) continue;
                gender = Genders[genderKey];
                return true;
            }

            return false;
        }
    }
}