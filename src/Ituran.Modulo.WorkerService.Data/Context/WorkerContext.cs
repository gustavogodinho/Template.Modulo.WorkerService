using Ituran.Modulo.WorkerService.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ituran.Modulo.WorkerService.Data.Context
{
    public class WorkerContext : DbContext
    {
        public WorkerContext(DbContextOptions<WorkerContext> options) : base(options)
        {
        }
        public DbSet<ALERTA_SEGURANCA> ALERTA_SEGURANCA { get; set; }
        public DbSet<ALERTA_SEGURANCA_DADOS> ALERTA_SEGURANCA_DADOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
