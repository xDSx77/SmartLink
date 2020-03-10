using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebApplication.DataAccess.EfModels;

namespace WebApplication.DataAccess
{
    public class StatsRepository : Repository<DataAccess.EfModels.TStats, Dbo.Stat>, Interfaces.IStatsRepository
    {
        public StatsRepository(SmartLinksContext context, ILogger<StatsRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public List<Dbo.StatByUrl> GetStat(string sessionId)
        {
            var result = _context.StatByUrl.Where(x=>x.SessionId == sessionId).ToList();
            return _mapper.Map<List<Dbo.StatByUrl>>(result);
        }
    }
}
