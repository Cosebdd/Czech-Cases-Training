using System.Threading.Tasks;
using CzechCases.Database.Model;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CzechCases.Database.Repositories
{
    public class WordRepository
    {
        private readonly IMongoCollection<Word> _words;

        public WordRepository(DatabaseConnection database)
        {
            _words = database.GetCollection<Word>("CzechCases");
        }

        public async Task<Word> GetByWordAsync(string word)
        {
            return (await _words.FindAsync(w => w.WordCases.Singular.Nominativ[0] == word)).FirstOrDefault();
        }

        public async Task<Word[]> GetPage(int page, int limit)
        {
            return (await (await _words
                .Find(FilterDefinition<Word>.Empty)
                .Limit(limit).Skip(page * limit)
                .ToCursorAsync())
                .ToListAsync())
                .ToArray();
        }

        public async Task<Word> GetAsync(string id)
        {
            return (await _words.FindAsync(w => w.Id == id)).FirstOrDefault();
        }

        public async Task<Word[]> GetRandom(int limit)
        {
            return (await (await _words
                .AsQueryable()
                .Sample(limit)
                .ToCursorAsync())
                .ToListAsync())
                .ToArray();
        }

        public async Task<Word> CreateAsync(Word word)
        {
            await _words.InsertOneAsync(word);
            return word;
        }

        public async Task<DeleteResult> RemoveAsync(string word)
        {
            return await _words.DeleteOneAsync(w => w.WordCases.Singular.Nominativ[0] == word);
        }
    }
}
