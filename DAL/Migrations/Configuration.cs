namespace BCRS.Migrations
{
    using DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BCRS.BuildingServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BCRS.BuildingServiceContext context)
        {
            context.Set<Role>().AddOrUpdate(
                new Role { Id = 1, Name = "Admin"},
                new Role { Id = 2, Name = "User"}
            );
            context.Set<User>().AddOrUpdate(
                new User { Id = 1, Email = "admin", Password = "admin", Name = "admin", RoleId = 1, Surname = "admin" }
            );
        }
    }
}
