using System.Threading.Tasks;
using CzechCases.Database.Model;
using CzechCases.Database.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CzechCases.REST.Services
{
    public class WordService
    {
        private readonly WordRepository _wordsRepository;

        public WordService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CzechCasesDb"));
            var database = client.GetDatabase("CzechCasesDb");
            _wordsRepository = new WordRepository(database);
        }

        public async Task<Word> Get(string word)
        {
            return await _wordsRepository.Get(word);
        }

        public Word[] GetRandom(int quantity)
        {
            return _wordsRepository.GetRandom(quantity);
        }
    }
}
