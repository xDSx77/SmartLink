using System;
using System.Collections.Generic;

namespace WebApplication.DataAccess.EfModels
{
    public partial class TShorcuts
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Hash { get; set; }
        public string SessionId { get; set; }
    }
}
