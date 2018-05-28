using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Entities;
using DAL.EF.Entities;


namespace BLL.Infrastructure
{
   public class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DbProduct, Product>();
                cfg.CreateMap<DbSubCategory, SubCategory>();
                cfg.CreateMap<DbMainCategory, MainCategory>();
                cfg.CreateMap<DbUserGroup, UserGroup>();
                cfg.CreateMap<DbUser, User>();
            });
        }

    }
}
