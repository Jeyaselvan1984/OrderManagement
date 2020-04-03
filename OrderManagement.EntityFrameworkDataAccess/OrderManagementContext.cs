using OrderManagement.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OrderManagement.EntityFrameworkDataAccess
{
    class OrderManagementContext :DbContext
    {
        public DbSet<OrderPoco> Orders { get; set; }
        public DbSet<ProductPoco> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderPoco>
           (entity =>
           {
               entity.HasOne(e => e.Product)
               .WithMany(f => f.Orders).HasForeignKey(e => e.Product);

         

           });
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            string _connStr = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
            optionsBuilder.UseSqlServer(_connStr);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
