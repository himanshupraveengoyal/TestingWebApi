using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestingWebApi.Models;
using TestingWebApi.Repository;

namespace TestingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        readonly ITesting _testingRepository;
        public TestingController()
        {
            _testingRepository = new Testing();
        }

        [HttpPost]
        [Route("SaveData")]
        public async Task<ActionResult> SaveData(string name,string desc)
        {
            Object result = JsonConvert.SerializeObject(
                await _testingRepository.SaveMessages(new Dictionary<string, string> { { "name", name },{ "desc", desc } },"SP_SaveMessage"
                ));
            return Ok(result);
        }
    }
}
