using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Dbo
{
    public class Stat : IObjectWithId
    {
        public long Id { get; set; }
        public long IdUrl { get; set; }
        public DateTime Date { get; set; }
    }
}
