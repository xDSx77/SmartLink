using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DataAccess
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Dbo.Shortcut, EfModels.TShorcuts>();
            CreateMap<EfModels.TShorcuts, Dbo.Shortcut>();

            CreateMap<Dbo.Stat, EfModels.TStats>();
            CreateMap<EfModels.TStats, Dbo.Stat>();

            CreateMap<Dbo.StatByUrl, EfModels.StatByUrl>();
            CreateMap<EfModels.StatByUrl, Dbo.StatByUrl>();
        }
    }
}
