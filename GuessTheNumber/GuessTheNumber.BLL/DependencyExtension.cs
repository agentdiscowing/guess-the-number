using GuessTheNumber.Core;
using GuessTheNumber.DAL;
using GuessTheNumber.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace GuessTheNumber.BLL
{
    public static class DependencyExtension
    {
        public static IServiceCollection AddRepository<T>(this IServiceCollection services)
            where T : BaseEntity
        {
            return services.AddScoped(typeof(IRepository<T>), typeof(Repository<T>));
        }

    }
}