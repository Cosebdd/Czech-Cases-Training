using System;
using System.Threading.Tasks;
using CzechCases.Database;
using CzechCases.Database.Model;
using CzechCases.Database.Repositories;

namespace CzechCases.Aggregator
{
    public class WordPutter
    {
        private const string DbName = "CzechCasesDb";
        private const string Server = "localhost";
        private const int Port = 27017;

        private readonly WordRepository _wordsRepository;

        public WordPutter()
        {
            var database = DatabaseConnection.CreateConnection(DbName, Server, Port);
            _wordsRepository = new WordRepository(database);
        }

        public async Task<Word> Create(Word word)
        {
            Console.WriteLine(word.WordCases.Singular.Nominativ[0]);
            return await _wordsRepository.CreateAsync(word);
        }
    }
}
