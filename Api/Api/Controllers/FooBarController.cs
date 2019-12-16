using System;
using System.Threading.Tasks;
using Api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class FooBarController : ControllerBase
    {
        private readonly ILogger<FooBarController> _logger;
        private readonly IFooBarService _fooBarService;

        public FooBarController(ILogger<FooBarController> logger, IFooBarService fooBarService)
        {
            _logger = logger;
            _fooBarService = fooBarService;
        }

        [HttpGet("{number}")]
        public async Task<IActionResult> Get(int number)
        {
            try
            {
                var result = await _fooBarService.GetFooBarAsync(number);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Please supply valid data");
            }
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll([FromQuery]int from, [FromQuery]int to)
        {
            try
            {
                var result = await _fooBarService.GetFooBarResultsAsync(from, to);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Please supply valid data");
            }
        }

        [HttpPost]
        [Route("validate")]
        public async Task<IActionResult> Validate([FromBody] FooBarResult fooBarResult)
        {
            try
            {
                if (fooBarResult == null)
                {
                    return BadRequest("Please supply valid data");
                }
                if (await _fooBarService.ValidateAsync(fooBarResult))
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
