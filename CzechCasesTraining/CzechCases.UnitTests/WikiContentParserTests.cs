using CzechCases.Model;
using CzechCases.Wiktionary.Parsing;
using NUnit.Framework;

namespace CzechCases.UnitTests
{
    [TestFixture]
    public class WikiContentParserTests
    {
        [Test]
        public void TestProperPageParsing()
        {
            var singleCases = new WordCases("burgán", "burgánu", "burgánu", "burgán", "burgáne", "burgánu", "burgánem");
            var pluralCases = new WordCases("burgány", "burgánů", "burgánům", "burgány", "burgány", "burgánech", "burgány");
            var allCases = new WordAllCases(singleCases, pluralCases);
            var expectedWord = new Word(allCases, GrammaticalGender.MaleInanimate);
            var pageIsParsed = WikiContentParser.TryParseWikiContent(Articles.ProperArticle, out var word);
            Assert.IsTrue(pageIsParsed);

            Assert.IsTrue(WordEqualityComparer.Equals(expectedWord, word));

        }

        [Test]
        public void TestUnproperPageParsing()
        {
            var pageIsParsed = WikiContentParser.TryParseWikiContent(Articles.BadArticle, out var word);
            Assert.IsFalse(pageIsParsed);
            Assert.IsNull(word);
        }

        [Test]
        public void TestMultipleLanguagesPageParsing()
        {
            var singleCases = new WordCases(new[] { "pes" }, new[] { "psa" }, new[] { "psovi", "psu"}, new [] {"psa"}, new [] {"pse"}, new [] {"psovi","psu" }, new[] { "psem" });
            var pluralCases = new WordCases(new[] { "psi", "psové" }, new[] { "psů" }, new[] { "psům" }, new[] { "psy" }, new[] { "psi", "psové" }, new[] { "psech" }, new[] { "psy" });
            var allCases = new WordAllCases(singleCases, pluralCases);
            var expectedWord = new Word(allCases, GrammaticalGender.MaleAnimate);
            var pageIsParsed = WikiContentParser.TryParseWikiContent(Articles.MultipleLanguagesArticle, out var word);
            Assert.IsTrue(pageIsParsed);

            Assert.IsTrue(WordEqualityComparer.Equals(expectedWord, word));
        }
    }
}
