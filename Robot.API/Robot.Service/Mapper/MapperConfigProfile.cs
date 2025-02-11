using AutoMapper;
using Robot.Repository.Entities;
using Robot.Service.BussinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Service.Mapper
{
    public class MapperConfigProfile: Profile
    {
        public MapperConfigProfile()
        {
            CreateMap<LogModel, Log>().ReverseMap();
        }
    }
}
