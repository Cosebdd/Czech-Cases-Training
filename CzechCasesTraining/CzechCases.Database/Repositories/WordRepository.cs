using System.Linq;
using System.Threading.Tasks;
using CzechCases.Database.Model;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CzechCases.Database.Repositories
{
    public class WordRepository
    {
        private readonly IMongoCollection<Word> _words;

        public WordRepository(IMongoDatabase database)
        {
            _words = database.GetCollection<Word>("CzechCases");
        }

        public async Task<Word> Get(string word)
        {
            return (await _words.FindAsync(w => w.WordCases.Singular.Nominativ[0] == word)).FirstOrDefault();
        }

        public Word[] GetRandom(int quantity)
        {
            return _words.AsQueryable().Sample(quantity).ToArray();
        }

        public async Task<Word> Create(Word word)
        {
            await _words.InsertOneAsync(word);
            return word;
        }

        public async Task<DeleteResult> Remove(string word)
        {
            return await _words.DeleteOneAsync(w => w.WordCases.Singular.Nominativ[0] == word);
        }
    }
}
