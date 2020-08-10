using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotnetCoreApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Linq;

namespace DotnetCoreApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        private static readonly string[] _examples = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public FooController(ILogger logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _examples.Select(x => new Foo { Id = Guid.NewGuid(), Name = x }).ToList();

            var dto = _mapper.Map<List<Foo>, List<FooDto>>(result);

            _logger.Information("getting {count} foos", result.Count);

            return Ok(result);
        }
    }
}
