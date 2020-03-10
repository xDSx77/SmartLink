using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
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

        [HttpGet("{sessionId}")]
        public object Get(string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId))
                return RedirectToPage("/Index");
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            List<Dbo.StatByUrl> stats = _statsRepository.GetStat(sessionId);
            return JsonSerializer.Serialize(stats, typeof(List<Dbo.StatByUrl>), options);
        }
    }
}
