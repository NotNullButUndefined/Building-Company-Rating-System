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



            context.Set<Company>().AddOrUpdate( new Company
            {
                Id = 5,
                Name = " иъвм≥ськбуд",
                Owner =2,
                logo = "https://photos-1.dropbox.com/t/2/AAAwlpkP-ZwOIqGN-S1mIjdi3JY4izbiiFSlR4Q4BjOVmw/12/203834114/png/32x32/1/_/1/2/kmb-logo.png/EKrzhJoBGJsTIAIoAg/NaB02tCM-AN9R8t8z1e7-V-_4dayejzmFIR-7AsuqFw?size=1280x960&size_mode=3"

            });

            context.Set<Company>().AddOrUpdate(new Company
            {

                Id = 6,
                Name = "≤тегралЅуд",
                Owner = 2,
                logo = "https://photos-1.dropbox.com/t/2/AACp2L17poDmMuw-q8rLgEX66tWS9s0VxNzHOK8kxuJ47A/12/203834114/png/32x32/1/_/1/2/156.png/EKrzhJoBGJsTIAIoAg/LvnDE-5fxZoGnSYyIK06-cJHU_tB2bBCKk0k2qjQDuE?size=1280x960&size_mode=3"
            });

            context.Set<Company>().AddOrUpdate(new Company
            {
                Id = 7,
                Name = "”крЅуд",
                Owner = 2,
                logo = "https://photos-6.dropbox.com/t/2/AADt7_ce_8QMXt0HTG5DFxEPXJ5Tx3VjvK9IzA5bcLKzPQ/12/203834114/png/32x32/1/_/1/2/logo-big-ukrbud.png/EKrzhJoBGJsTIAIoAg/4KseeHFESyNkfY9pzRMYgRMQm6NsWFH6TSJCk4Y25qA?size=1280x960&size_mode=3"
            });

            context.Set<Company>().AddOrUpdate(new Company
            {
                Id = 8,
                Name = "Lego house",
                Owner = 2,
                logo = "https://photos-3.dropbox.com/t/2/AADq2Y6fJIHDPzcL33NW-5XHEgyGDaGQSQFy9DHBLlR00Q/12/203834114/jpeg/32x32/1/_/1/2/41876de5b6cfa471fa2e53ebbbb7c.jpg/EKrzhJoBGJsTIAIoAg/IQP8_6KfhbAVfQIMN--ZhKFJtBTmxjmNZKRGPw7LXtI?size=1280x960&size_mode=3"
            });

            context.Set<Company>().AddOrUpdate(new Company
            {
                Id = 9,
                Name = "Ќова будова",
                Owner = 2,
                logo = "https://photos-4.dropbox.com/t/2/AADDgDldwFu0hf42-zQUbkifU8kRlFqBwfo6pZCoBGDpmg/12/203834114/png/32x32/1/_/1/2/336.png/EKrzhJoBGJsTIAIoAg/FFCPy44qxam4McyMScMhzUYA9Gd5Ngfki6Hyjc_sgO8?size=1280x960&size_mode=3"

            });

            context.Set<Company>().AddOrUpdate(new Company
            {
                Id = 10,
                Name = "≈вропейске м≥сто",
                Owner = 2,
                logo = "https://photos-2.dropbox.com/t/2/AACNvAvqU4TQ6AtVPpofJMNEv9iqrObnTKCIVhCQ6XiI6g/12/203834114/png/32x32/1/_/1/2/iubouno.png/EKrzhJoBGJsTIAIoAg/RwphHkon--qUsEBGEk8vseD1o8hFuy-lnZvswRsETCw?size=1280x960&size_mode=3"
            }
            );

            context.Set<Building>().AddOrUpdate(new Building
            {
                Id = 2,
                Name = "Urlovskaya 23-V",
                FoundationDate = new DateTime(2013, 1, 5),
                CompanyId = 5,
                TotalRating = 4
            });

            context.Set<Building>().AddOrUpdate(new Building
            {
                Id = 2,
                Name = "Urlovskaya 23-V",
                FoundationDate = new DateTime(2013, 1, 5),
                CompanyId = 5,
                TotalRating = 4
            });

            context.Set<Building>().AddOrUpdate(new Building
            {
                Id = 2,
                Name = "Dneprovskaya Naberezhnaya 37",
                FoundationDate = new DateTime(2013, 2, 5),
                CompanyId = 5,
                TotalRating = 5
            });

        }
    }
}
