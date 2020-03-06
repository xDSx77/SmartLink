using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Dbo
{
    public class Shortcut
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Hash { get; set; }
        public int SessionId { get; set; }
    }
}
