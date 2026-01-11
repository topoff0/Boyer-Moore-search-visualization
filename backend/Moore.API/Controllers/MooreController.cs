using Microsoft.AspNetCore.Mvc;
using Moore.Core.Entities;
using Moore.Core.Interfaces;
using Moore.Core.RequestDtos;

namespace Moore.API.Controllers
{
    [ApiController]
    [Route("api/moore")]
    public class MooreController(IMooreService mooreService) : ControllerBase
    {
        private readonly IMooreService _mooreService = mooreService;

        [HttpPost("execute")]
        public IActionResult SearchSubSting([FromBody] SearchRequest request)
        {
            //FIX: Bug with equals string such as "string" and "string" (return: found = false)
            MooreAlgorithm algo = new(request);
            var result = _mooreService.Search(algo);
            return Ok(result);
        }
    }
}
