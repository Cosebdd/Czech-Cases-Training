using System.Diagnostics;

namespace CzechCases.Model
{
    [DebuggerDisplay("{string.Join(\" / \",Nominativ)} {string.Join(\" / \",Genitiv)} {string.Join(\" / \",Dativ)} {string.Join(\" / \",Akuzativ)} {string.Join(\" / \",Vokativ)} {string.Join(\" / \",Lokal)} {string.Join(\" / \",Instrumental)}")]
    public class WordCases
    {
        public WordCases(string[] nominativ, string[] genitiv, string[] dativ, string[] akuzativ, string[] vokativ, string[] lokal, string[] instrumental)
        {
            
            Nominativ = nominativ;
            Genitiv = genitiv;
            Dativ = dativ;
            Akuzativ = akuzativ;
            Vokativ = vokativ;
            Lokal = lokal;
            Instrumental = instrumental;
        }

        public WordCases(string nominativ, string genitiv, string dativ, string akuzativ, string vokativ, string lokal, string instrumental) : this(
            new []{nominativ}, new []{genitiv}, new []{dativ}, new []{akuzativ}, new []{vokativ}, new []{lokal}, new []{instrumental})
        {
        }

        public string[] Nominativ { get; }
        public string[] Genitiv { get; }
        public string[] Dativ { get; }
        public string[] Akuzativ { get; }
        public string[] Vokativ { get; }
        public string[] Lokal { get; }
        public string[] Instrumental { get; }
    }

    public class WordAllCases
    {
        public WordAllCases(WordCases singular, WordCases plural)
        {
            Singular = singular;
            Plural = plural;
        }

        public WordCases Singular { get; }
        public WordCases Plural { get; }
    }
}