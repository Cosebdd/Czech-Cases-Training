using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzechCases.Database.Model;
using CzechCases.REST.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CzechCases.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly WordService _wordService;

        public WordController(WordService wordService)
        {
            _wordService = wordService;
        }

        [HttpGet("{quantity}")]
        public Word[] Get(int quantity)
        {
            return _wordService.GetRandom(quantity);
        }
    }
}
