using FlowerServiceLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerService.Services {
    public class FlowerServiceContext : DbContext {

        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Plantation> Plantations { get; set; }
        public DbSet<PlantationFlower> PlantationFlowers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseFlower> WarehouseFlowers { get; set; }
        public DbSet<Supply> Supply { get; set; }
        public DbSet<SupplyFlower> SupplyFlowers { get; set; }

        public FlowerServiceContext(DbContextOptions<FlowerServiceContext> options): base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<PlantationFlower>().HasKey(flower => new { flower.PlaceId, flower.FlowerId });
            modelBuilder.Entity<WarehouseFlower>().HasKey(flower => new { flower.PlaceId, flower.FlowerId });
            modelBuilder.Entity<SupplyFlower>().HasKey(flower => new { flower.SupplyId, flower.FlowerId });

            //TODO add cascade delet

            base.OnModelCreating(modelBuilder);
        }


    }
}
