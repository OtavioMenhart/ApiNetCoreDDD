using ApiNetCore.Data.Context;
using ApiNetCore.Data.Implementations;
using ApiNetCore.Data.Repository;
using ApiNetCore.Domain.Interfaces;
using ApiNetCore.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNetCore.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost; Port=3306;Database=db_apinetcore; Uid=root; Pwd=local@123")
                );

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
        }
    }
}
