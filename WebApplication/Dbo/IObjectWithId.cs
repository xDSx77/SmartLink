using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Dbo
{
    public interface IObjectWithId
    {
        public int Id { get; set; }
    }
}
