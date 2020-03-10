using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DataAccess.Interfaces
{
    public interface IShortcutsRepository : DataAccess.IRepository<EfModels.TShorcuts, Dbo.Shortcut>
    {
        Dbo.Shortcut GetByHash(string hash);
        List<Dbo.Shortcut> GetBySessionId(string sessionId);
    }
}
