using System.Net;
using System.Security.Claims;
using System;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Ashdod_Port.Data
{
    public class DataContextServies : DbContext
    {
        public DbSet<Container> ContainersList { get; set; }
        public DbSet<Importer> ImportersLst { get; set; }
        public DbSet<Supplier> SuppliersLst { get; set; }
        public readonly IConfiguration _configuration;
        public DataContextServies(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB ;Database=port_DBB2")
        //        .LogTo(Console.WriteLine, LogLevel.Information);
        //}

    }

}
