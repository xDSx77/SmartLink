using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class StatsController : Controller
    {
        private readonly ILogger<StatsController> _logger;
        private readonly DataAccess.Interfaces.IStatsRepository _statsRepository;

        public StatsController(ILogger<StatsController> logger, DataAccess.Interfaces.IStatsRepository statsRepository)
        {
            _logger = logger;
            _statsRepository = statsRepository;
        }

        // GET api/<controller>/5
        [HttpGet("{sessionId}")]
        public object Get(string sessionId)
        {
            /*if (string.IsNullOrEmpty(sessionId))
            {
                return BadRequest();
            }*/
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            List<Dbo.StatByUrl> stats = _statsRepository.GetStat(sessionId);
            return JsonSerializer.Serialize(stats, typeof(List<Dbo.StatByUrl>), options);
        }
    }
}
