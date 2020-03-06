using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DataAccess
{
    public class AutomapperProfiles : AutoMapper.Profile
    {
        public static IMapper Mapper 
        {
            get
            {
                if (Mapper == null)
                    ConfWithProfile();
                return Mapper;
            }
            set
            { }
        }

        private static void ConfWithProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperProfiles>();
            });
            Mapper = config.CreateMapper();
        }

        public AutomapperProfiles()
        {
            CreateMap<EfModels.TShortcuts, Dbo.Shortcut>();
            CreateMap<Dbo.Shortcut, EfModels.TShortcuts>();

            CreateMap<EfModels.TStats, Dbo.Stat>();
            CreateMap<Dbo.Stat, EfModels.TStats>();

            CreateMap<EfModels.StatByUrl, Dbo.StatByUrl>();
            CreateMap<Dbo.StatByUrl, EfModels.StatByUrl>();
        }
    }
}
