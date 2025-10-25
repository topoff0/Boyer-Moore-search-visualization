using Microsoft.AspNetCore.Mvc;
using Moore.Core.Entities;
using Moore.Core.Interfaces;
using Moore.Core.RequestDtos;

namespace Moore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MooreController : ControllerBase
    {
        private readonly IMooreService _mooreService;

        public MooreController(IMooreService mooreService)
        {
            _mooreService = mooreService;
        }

        [HttpPost]
        public IActionResult SearchSubSting([FromBody] SearchRequest request)
        {
            MooreAlgorithm algo = new(request);
            var result = _mooreService.Search(algo);
            return Ok(result);
        }
    }
}