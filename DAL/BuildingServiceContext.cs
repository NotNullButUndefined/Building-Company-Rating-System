﻿using BCRS.Migrations;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BCRS
{
    public class BuildingServiceContext : DbContext
    {
        public BuildingServiceContext() : base("name=BuildingServiceContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BuildingServiceContext, Configuration>("BuildingServiceContext"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<Role>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<User>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<Company>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<Building>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<Rating>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<Comment>());
        }

        public System.Data.Entity.DbSet<DAL.Entities.User> Users { get; set; }

        public System.Data.Entity.DbSet<DAL.Entities.Role> Roles { get; set; }
    }
}