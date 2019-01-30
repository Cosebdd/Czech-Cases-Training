using System.Diagnostics;
using MongoDB.Bson.Serialization.Attributes;

namespace CzechCases.Database.Model
{
    [DebuggerDisplay("{string.Join(\" / \",Nominativ)} {string.Join(\" / \",Genitiv)} {string.Join(\" / \",Dativ)} {string.Join(\" / \",Akuzativ)} {string.Join(\" / \",Vokativ)} {string.Join(\" / \",Lokal)} {string.Join(\" / \",Instrumental)}")]
    public class WordCases
    {
        [BsonElement("Nominativ")]
        public string[] Nominativ { get; set; }
        [BsonElement("Genitiv")]
        public string[] Genitiv { get; set; }
        [BsonElement("Dativ")]
        public string[] Dativ { get; set; }
        [BsonElement("Akuzativ")]
        public string[] Akuzativ { get; set; }
        [BsonElement("Vokativ")]
        public string[] Vokativ { get; set; }
        [BsonElement("Lokal")]
        public string[] Lokal { get; set; }
        [BsonElement("Instrumental")]
        public string[] Instrumental { get; set; }
    }

    public class WordAllCases
    {
        [BsonElement("Singular")]
        public WordCases Singular { get; set; }
        [BsonElement("Plural")]
        public WordCases Plural { get; set; }
    }
}