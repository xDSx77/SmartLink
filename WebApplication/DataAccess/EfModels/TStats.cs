using System;
using System.Collections.Generic;

namespace WebApplication.DataAccess.EfModels
{
    public partial class TStats : Dbo.IObjectWithId
    {
        public int Id { get; set; }
        public int IdUrl { get; set; }
        public DateTime Date { get; set; }

        public virtual TShortcuts IdUrlNavigation { get; set; }
    }
}
