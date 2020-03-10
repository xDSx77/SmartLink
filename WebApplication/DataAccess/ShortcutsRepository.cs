using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebApplication.DataAccess.EfModels;

namespace WebApplication.DataAccess
{
    public class ShortcutsRepository : Repository<EfModels.TShorcuts, Dbo.Shortcut>, Interfaces.IShortcutsRepository
    {
        public ShortcutsRepository(SmartLinksContext context, ILogger<ShortcutsRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public Dbo.Shortcut GetByHash(string hash)
        {
            var result = _context.TShorcuts.FirstOrDefault(x => x.Hash == hash);
            return _mapper.Map<Dbo.Shortcut>(result);
        }

        public List<Dbo.Shortcut> GetBySessionId(string sessionId)
        {
            var result = _context.TShorcuts.Where(x => x.SessionId == sessionId).ToList();
            return _mapper.Map<List<Dbo.Shortcut>>(result);
        }
    }
}
