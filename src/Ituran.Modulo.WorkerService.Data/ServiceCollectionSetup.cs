using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using Ituran.Modulo.WorkerService.Data.Context;

namespace Ituran.Modulo.WorkerService.Data
{
    public static class ServiceCollectionSetup
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration) =>
           services.AddDbContext<WorkerContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection")));
    }
}
