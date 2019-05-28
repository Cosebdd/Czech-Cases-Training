using System.Threading.Tasks;
using CzechCases.Database.Model;
using CzechCases.REST.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CzechCases.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomWordsController : ControllerBase
    {

        private readonly WordService _wordService;

        public RandomWordsController(WordService wordService)
        {
            _wordService = wordService;
        }

        [HttpGet]
        public async Task<Word[]> Get([FromQuery]int? limit)
        {
            return await _wordService.GetRandom(limit ?? CommonConstants.DefaultLimit);
        }
    }
}
