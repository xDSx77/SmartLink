using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DataAccess
{
    public class ShortcutsRepository : Repository<Dbo.Shortcut, EfModels.TShortcuts>, IShortcutsRepository
    {
        public ShortcutsRepository(EfModels.SmartLinkContext context, ILogger logger)
            : base(context, logger)
        {
        }
    }
}
