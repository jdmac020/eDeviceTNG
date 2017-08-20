using EDeviceClaims.Entities;
using EDeviceClaims.Repositories.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EDeviceClaims.Core;

namespace EDeviceClaims.Repositories.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<EDeviceClaims.Repositories.Contexts.EDeviceClaimsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EDeviceClaims.Repositories.Contexts.EDeviceClaimsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            SetStatuses();

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            roleManager.Create(new IdentityRole { Name = AppRoles.Admin });
            roleManager.Create(new IdentityRole { Name = AppRoles.Underwriter });
            roleManager.Create(new IdentityRole { Name = AppRoles.PolicyHolder });

            var policyHolder = CreateUser("user@personal.com", "user@personal.com", "Policy", "Holder", context);
            CreateUser("admin@company.com", "admin@company.com", "Admin", "Guy", context, AppRoles.Admin);
            CreateUser("callcenter@company.com", "callcenter@company.com", "Under", "Writer", context, AppRoles.Underwriter);

            var amanda = CreateUser("amanda@personal.com", "amanda@personal.com", "Amanda", "M", context);
            var julie = CreateUser("julie@personal.com", "julie@personal.com", "Julie", "W", context);
            var david = CreateUser("david@personal.com", "david@personal.com", "Dave", "M", context);
            var katie = CreateUser("katie@personal.com", "katie@personal.com", "Katie", "M", context);
            var jeannine = CreateUser("jeannine@personal.com", "jeannine@personal.com", "Jeannine", "K", context);
            var sam = CreateUser("sam@personal.com", "sam@personal.com", "Sam", "K", context);
            var ali = CreateUser("ali@personal.com", "ali@personal.com", "Ali", "K", context);
            var joe = CreateUser("joe@personal.com", "joe@personal.com", "Joe", "S", context);
            var maria = CreateUser("marias@personal.com", "marias@personal.com", "Maria", "S", context);
            var elizabeth = CreateUser("elizabeth@personal.com", "elizabeth@personal.com", "Liz", "M", context);
            var mariap = CreateUser("mariap@personal.com", "mariap@personal.com", "Maria", "P", context);

            var p1 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "12345",
                SerialNumber = "ABCDEF",
                DeviceName = "iPhone 6+",
                CustomerEmail = "user@personal.com",
                UserId = policyHolder.Id
            };
            var p2 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "67890",
                SerialNumber = "GHIJKL",
                DeviceName = "Android",
                CustomerEmail = "user@personal.com",
                UserId = policyHolder.Id

            };

            var p3 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "123",
                SerialNumber = "ABC",
                DeviceName = "MacBook",
                CustomerEmail = "amanda@personal.com",
                UserId = amanda.Id
            };
            var p4 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "456",
                SerialNumber = "DEF",
                DeviceName = "Android",
                CustomerEmail = "amanda@personal.com",
                UserId = amanda.Id

            };

            var p5 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "789",
                SerialNumber = "GHI",
                DeviceName = "Samsung Sx",
                CustomerEmail = "julie@personal.com",
                UserId = julie.Id
            };
            var p6 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "012",
                SerialNumber = "JKL",
                DeviceName = "Kindle",
                CustomerEmail = "user@personal.com",
                UserId = julie.Id

            };

            var p7 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "345",
                SerialNumber = "MNO",
                DeviceName = "Palm+",
                CustomerEmail = "david@personal.com",
                UserId = david.Id
            };
            var p8 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "678",
                SerialNumber = "PQR",
                DeviceName = "Echo",
                CustomerEmail = "david@personal.com",
                UserId = david.Id

            };

            var p9 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "901",
                SerialNumber = "STU",
                DeviceName = "Samsung Sx",
                CustomerEmail = "katie@personal.com",
                UserId = katie.Id
            };
            var p10 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "234",
                SerialNumber = "VWX",
                DeviceName = "Toshiba",
                CustomerEmail = "katie@personal.com",
                UserId = katie.Id

            };

            var p11 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "567",
                SerialNumber = "YZA",
                DeviceName = "iPhone 6+",
                CustomerEmail = "jeannine@personal.com",
                UserId = jeannine.Id
            };
            var p12 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "890",
                SerialNumber = "BCD",
                DeviceName = "iPad",
                CustomerEmail = "jeannine@personal.com",
                UserId = jeannine.Id

            };

            var p13 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "123",
                SerialNumber = "EFG",
                DeviceName = "Nintendo Switch",
                CustomerEmail = "sam@personal.com",
                UserId = sam.Id
            };
            var p14 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "456",
                SerialNumber = "HIJ",
                DeviceName = "iPadMini",
                CustomerEmail = "sam@personal.com",
                UserId = sam.Id

            };

            var p15 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "789",
                SerialNumber = "IKL",
                DeviceName = "Nintendo DS",
                CustomerEmail = "ali@personal.com",
                UserId = ali.Id
            };
            var p16 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "012",
                SerialNumber = "MNO",
                DeviceName = "iPhone4",
                CustomerEmail = "ali@personal.com",
                UserId = ali.Id

            };

            var p17 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "345",
                SerialNumber = "PQR",
                DeviceName = "iPhone 6+",
                CustomerEmail = "joe@personal.com",
                UserId = joe.Id
            };
            var p18 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "678",
                SerialNumber = "STU",
                DeviceName = "Dell",
                CustomerEmail = "joe@personal.com",
                UserId = joe.Id

            };

            var p19 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "901",
                SerialNumber = "VWX",
                DeviceName = "Moto",
                CustomerEmail = "marias@personal.com",
                UserId = maria.Id
            };
            var p20 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "234",
                SerialNumber = "YZA",
                DeviceName = "Dell",
                CustomerEmail = "marias@personal.com",
                UserId = maria.Id

            };

            var p21 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "567",
                SerialNumber = "BCD",
                DeviceName = "Moto",
                CustomerEmail = "elizabeth@personal.com",
                UserId = elizabeth.Id
            };
            var p22 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "890",
                SerialNumber = "EFG",
                DeviceName = "Surface",
                CustomerEmail = "elizabeth@personal.com",
                UserId = elizabeth.Id

            };

            var p23 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "123",
                SerialNumber = "HIJ",
                DeviceName = "iPhone 6+",
                CustomerEmail = "mariap@personal.com",
                UserId = mariap.Id
            };
            var p24 = new Policy
            {
                Id = Guid.NewGuid(),
                Number = "456",
                SerialNumber = "KLM",
                DeviceName = "MacBook",
                CustomerEmail = "mariap@personal.com",
                UserId = mariap.Id

            };

            context.Policies.AddOrUpdate(
              p => p.Number,
              p1,
              p2,
              p3,
              p4,
              p5,
              p6,
              p7,
              p8,
              p9,
              p10,
              p11,
              p12,
              p13,
              p14,
              p15,
              p16,
              p17,
              p18,
              p20,
              p21,
              p22,
              p23,
              p24,
              new Policy { Id = Guid.NewGuid(), Number = "11121", SerialNumber = "MNOPQ", DeviceName = "iPhone 6+", CustomerEmail = "d@b.com" },
              new Policy { Id = Guid.NewGuid(), Number = "31415", SerialNumber = "RSTUV", DeviceName = "iPhone 6+", CustomerEmail = "e@b.com" },
              new Policy { Id = Guid.NewGuid(), Number = "16171", SerialNumber = "WXYZA", DeviceName = "iPhone 6+", CustomerEmail = "f@b.com" },
              new Policy { Id = Guid.NewGuid(), Number = "81920", SerialNumber = "BCDEF", DeviceName = "iPhone 6+", CustomerEmail = "g@b.com" },
              new Policy { Id = Guid.NewGuid(), Number = "21222", SerialNumber = "GHIJK", DeviceName = "iPhone 6+", CustomerEmail = "h@b.com" },
              new Policy { Id = Guid.NewGuid(), Number = "32425", SerialNumber = "LMNOP", DeviceName = "iPhone 6+", CustomerEmail = "i@b.com" },
              new Policy { Id = Guid.NewGuid(), Number = "26272", SerialNumber = "QRSTU", DeviceName = "iPhone 6+", CustomerEmail = "j@b.com" }
            );

            //policyHolder.UserPolicies.Add(p1);
            //policyHolder.UserPolicies.Add(p2);
            //context.SaveChanges();
        }

        private AuthorizedUser CreateUser(string userName, string email, string firstName, string lastName, EDeviceClaimsContext context, string role = AppRoles.PolicyHolder)
        {
            var userStore = new UserStore<AuthorizedUser>(context);
            var userManager = new UserManager<AuthorizedUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var user = userManager.FindByEmail(email);

            if (user != null) return user;

            user = new AuthorizedUser
            {
                UserName = userName,
                Email = email,
                FirstName = firstName,
                LastName = lastName
            };
            userManager.Create(user, "password");
            roleManager.Create(new IdentityRole { Name = role });
            userManager.AddToRole(user.Id, role);
            return user;
        }

        private void SetStatuses()
        {
            var statusRepo = new StatusRepository();
            var statuses = Enum.GetNames(typeof(ClaimStatusOptions)).ToList();

            if (statusRepo.GetAll().Count > 0) return;

            foreach (var status in statuses)
            {
                var newStatus = new StatusEntity {Id = Guid.NewGuid(), Name = status};

                statusRepo.Create(newStatus);
            }
        }
    }
}
