using AutoMapper;
using BikeDiller.App.Models.BikeModels;
using BikeDiller.App.Models.MakeModels;
using BikeDiller.App.Models.ModelModels;
using BikeDiller.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDiller.App.Profiles
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Make, MakeListVM>().ReverseMap();
            CreateMap<MakeCreateVM, Make>().ReverseMap();
            CreateMap<Make, MakeEditVM>().ReverseMap();


            CreateMap<ModelCreateVM, Model>().ReverseMap();
            CreateMap<ModelEditVM, Model>().ReverseMap();

            CreateMap<Bike, BikeCreateVM>().ReverseMap();
            CreateMap<BikeListVM, Bike>().ReverseMap();
            CreateMap<Bike, BikeEditVM>().ReverseMap();



        }
    }
}
