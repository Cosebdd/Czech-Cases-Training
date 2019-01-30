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
