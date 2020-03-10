using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;

namespace WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DataAccess.Interfaces.IShortcutsRepository _shortcutsRepository;
        private readonly DataAccess.Interfaces.IStatsRepository _statsRepository;

        [BindProperty]
        public string UrlInput { get; set; }
        [BindProperty]
        public IEnumerable<Dbo.Shortcut> Shortcuts { get; set; }

        public const string SessionKeyId = "_Id";

        public async Task OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyId)))
            {
                HttpContext.Session.SetString(SessionKeyId, Guid.NewGuid().ToString());
            }
            Shortcuts = _shortcutsRepository.GetBySessionId(HttpContext.Session.GetString(SessionKeyId));
        }

        public IndexModel(ILogger<IndexModel> logger, DataAccess.Interfaces.IShortcutsRepository shortcutsRepository, DataAccess.Interfaces.IStatsRepository statsRepository)
        {
            _logger = logger;
            _shortcutsRepository = shortcutsRepository;
            _statsRepository = statsRepository;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string hash = "";

            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(UrlInput));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                hash = sBuilder.ToString().Substring(0, 5);
            }
            await _shortcutsRepository.Insert(new Dbo.Shortcut()
            {
                Url = UrlInput,
                Hash = hash,
                SessionId = HttpContext.Session.GetString(SessionKeyId)
            });

            return RedirectToPage("./Index");
        }
    }
}
