using BikeDiller.DataBase;
using BikeDiller.Repositories;
using BikeDiller.Repositories.Abstraction;
using BikeDiller.Services;
using BikeDiller.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeDiller.App.Configurations
{
    public class AppConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BikeDillerDbContext>(options =>
                    options.UseSqlServer(@"Server = (local); Database = BikeDillerTest; Integrated Security = true"));


            
            services.AddTransient<IMakeService, MakeService>();
            services.AddTransient<IMakeRepository, MakeRepository>();

            services.AddTransient<IModelService, ModelService>();
            services.AddTransient<IModelRepository, ModelRepository>();

            services.AddTransient<IBikeRepository, BikeRepository>();
            services.AddTransient<IBikeService, BikeService>();

            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<ICurrencyService, CurrencyService>();

            
        }
    }
}
