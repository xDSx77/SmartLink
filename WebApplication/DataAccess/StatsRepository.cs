using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DataAccess
{
    public class StatsRepository : Repository<Dbo.Stat, EfModels.TStats>
    {
        public StatsRepository(EfModels.SmartLinkContext context, ILogger logger) :
            base(context, logger)
        {
        }
    }
}
