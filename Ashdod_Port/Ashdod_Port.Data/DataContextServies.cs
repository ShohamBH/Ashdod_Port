﻿using System.Net;
using System.Security.Claims;
using System;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Core.Entities;
<<<<<<< HEAD
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

=======

namespace Ashdod_Port.Data
{
    public class DataContextServies :IDataContext
    {
        public  List<Container> ContainersList { get; set; }
        public  List<Importer> ImportersLst { get; set; }
        public  List<Supplier> SuppliersLst { get; set; }

        public DataContextServies()
        {

            ContainersList = new List<Container>()
            {
                new Container("329","123",new DateTime(2025,10,05))
            };
            ImportersLst = new List<Importer>()
            {
                new Importer("shoham","329","hjk","13",4)
            };
            SuppliersLst = new List<Supplier>();
        }
    }
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
}
