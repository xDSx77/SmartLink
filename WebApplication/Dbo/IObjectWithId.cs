using System;

namespace WebApplication.Dbo
{
    public interface IObjectWithId
    {
        long Id { get; set; }
    }
}
