using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace paceproject.Models
{
    public class ServerDocDB : DbContext
    {
        public DbSet<Server> Servers { get; set; }
        public DbSet<Infrastructure> Infrastructures { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Make> Makes { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
  {
     modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
  }
    }
}