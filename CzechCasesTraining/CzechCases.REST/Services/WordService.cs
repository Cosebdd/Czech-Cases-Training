using System.Threading.Tasks;
using CzechCases.Database;
using CzechCases.Database.Model;
using CzechCases.Database.Repositories;
using Microsoft.Extensions.Configuration;

namespace CzechCases.REST.Services
{
    public class WordService
    {
        private readonly WordRepository _wordsRepository;
        private const string DefaultDbConnection = "CzechCasesDb";

        public WordService(IConfiguration config)
        {
            var dbCon = DatabaseConnection.CreateConnection(config.GetConnectionString(DefaultDbConnection), DefaultDbConnection);

            _wordsRepository = new WordRepository(dbCon);
        }

        public async Task<Word> GetByWord(string word)
        {
            return await _wordsRepository.GetAsync(word);
        }

        public async Task<Word> Get(string id)
        {
            return await _wordsRepository.GetAsync(id);
        }

        public async Task<Word[]> GetPage(int page, int limit)
        {
            return await _wordsRepository.GetPage(page, limit);
        }

        public async Task<Word[]> GetRandom(int limit)
        {
            return await _wordsRepository.GetRandom(limit);
        }
    }
}
