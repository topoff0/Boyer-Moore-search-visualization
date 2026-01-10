using Microsoft.AspNetCore.Mvc;
using Moore.Core.Entities;
using Moore.Core.Interfaces;
using Moore.Core.RequestDtos;

namespace Moore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MooreController(IMooreService mooreService) : ControllerBase
    {
        private readonly IMooreService _mooreService = mooreService;

        [HttpPost("moore/execute")]
        public IActionResult SearchSubSting([FromBody] SearchRequest request)
        {
            MooreAlgorithm algo = new(request);
            var result = _mooreService.Search(algo);
            return Ok(result);
        }
    }
}
