using System;
using System.Collections.Generic;

namespace WebApplication.DataAccess.EfModels
{
    public partial class TShortcuts : Dbo.IObjectWithId
    {
        public TShortcuts()
        {
            TStats = new HashSet<TStats>();
        }

        public int Id { get; set; }
        public string Url { get; set; }
        public string Hash { get; set; }
        public int SessionId { get; set; }

        public virtual ICollection<TStats> TStats { get; set; }
    }
}
