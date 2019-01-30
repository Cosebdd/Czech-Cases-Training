using System.Threading.Tasks;
using CzechCases.Database.Model;
using CzechCases.Database.Repositories;
using MongoDB.Driver;

namespace CzechCases.Aggregator
{
    public class WordPutter
    {
        private readonly WordRepository _wordsRepository;

        public WordPutter()
        {
            var client = new MongoClient(new MongoClientSettings() {ApplicationName = "CzechCasesDb", Server = new MongoServerAddress("localhost", 27017) });
            var database = client.GetDatabase("CzechCasesDb");
            _wordsRepository = new WordRepository(database);
        }

        public async Task<Word> Create(Word word)
        {
            return await _wordsRepository.Create(word);
        }
    }
}
