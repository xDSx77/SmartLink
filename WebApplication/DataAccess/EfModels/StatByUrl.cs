using System;
using System.Collections.Generic;

namespace WebApplication.DataAccess.EfModels
{
    public partial class StatByUrl
    {
        public string Url { get; set; }
        public int? Hit { get; set; }
        public string SessionId { get; set; }
    }
}
