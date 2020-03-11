using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    public class IndexController : Controller
    {
        private readonly ILogger<IndexController> _logger;

        private readonly DataAccess.Interfaces.IShortcutsRepository _shortcutsRepository;
        private readonly DataAccess.Interfaces.IStatsRepository _statsRepository;

        public IndexController(ILogger<IndexController> logger, DataAccess.Interfaces.IShortcutsRepository shortcutsRepository, DataAccess.Interfaces.IStatsRepository statsRepository)
        {
            _logger = logger;
            _shortcutsRepository = shortcutsRepository;
            _statsRepository = statsRepository;
        }

        [HttpGet("{hash}")]
        public async Task<IActionResult> GetAsync(string hash)
        {
            if (string.IsNullOrEmpty(hash))
            {
                _logger.LogError("Incorrect hash: string null or empty");
                return RedirectToPage("/Index");
            }
            string sessionKeyId = HttpContext.Session.GetString("_Id");
            List<Dbo.Shortcut> shortcuts = _shortcutsRepository.GetBySessionId(sessionKeyId);
            foreach(var shortcut in shortcuts)
            {
                if (shortcut.Hash == hash)
                {
                    await _statsRepository.Insert(new Dbo.Stat()
                    {
                        IdUrl = shortcut.Id,
                        Date = DateTime.Now
                    });
                    _logger.LogInformation("Stat entry correctly inserted");
                    return Redirect(shortcut.Url);
                }
            }
            _logger.LogWarning("Hash not found for this sessionId: stat not updated");
            return RedirectToPage("/Index");
        }
    }
}
