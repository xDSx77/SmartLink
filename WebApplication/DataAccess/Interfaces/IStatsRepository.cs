using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DataAccess.Interfaces
{
    public interface IStatsRepository : DataAccess.IRepository<EfModels.TStats, Dbo.Stat>
    {
        List<Dbo.StatByUrl> GetStat(string sessionId);
    }
}
