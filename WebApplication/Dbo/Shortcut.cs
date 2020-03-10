using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Dbo
{
    public class Shortcut : IObjectWithId
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Hash { get; set; }

        public string SessionId { get; set; }
    }
}
