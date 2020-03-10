using System;
using System.Collections.Generic;

namespace WebApplication.DataAccess.EfModels
{
    public partial class TStats
    {
        public long Id { get; set; }
        public long IdUrl { get; set; }
        public DateTime Date { get; set; }
    }
}
