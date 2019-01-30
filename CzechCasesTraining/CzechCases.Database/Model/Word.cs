using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CzechCases.Database.Model
{
    public class Word
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("WordCases")]
        public WordAllCases WordCases { get; set; }

        [BsonElement("Gender")]
        public GrammaticalGender Gender { get; set; }
    }
}
