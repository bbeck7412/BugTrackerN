namespace BugTracker.Migrations
{
    using BugTracker.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Configuration;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BugTracker.Models.ApplicationDbContext context)
        {
            #region Role Creation
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                roleManager.Create(new IdentityRole { Name = "Administrator" });
            }

            if (!context.Roles.Any(r => r.Name == "ProjectManager"))
            {
                roleManager.Create(new IdentityRole { Name = "ProjectManager" });
            }

            if (!context.Roles.Any(r => r.Name == "Developer"))
            {
                roleManager.Create(new IdentityRole { Name = "Developer" });
            }

            if (!context.Roles.Any(r => r.Name == "Submitter"))
            {
                roleManager.Create(new IdentityRole { Name = "Submitter" });
            }
            #endregion


            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var demoPassword = WebConfigurationManager.AppSettings["DemoUserPassword"];

            //Demo Users for admin, Administrator is for visitors Admin is personal credentials-----
            if (!context.Users.Any(u => u.Email == "Bbeck7412@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "Bbeck7412@gmail.com",
                    Email = "Bbeck7412@gmail.com",
                    FirstName = "Brandon",
                    LastName = "Beck",
                    DisplayName = "Brandon Beck"
                }, "Abc&123");
            }

            if (!context.Users.Any(u => u.Email == "DemoAdmin@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoAdmin@mailinator.com",
                    Email = "DemoAdmin@mailinator.com",
                    FirstName = "Demo",
                    LastName = "Admin",
                    DisplayName = "Demo Administrator"
                }, "DemoUserPassword");
            }


            //Demo Project Managers------------------------------------------------
            if (!context.Users.Any(u => u.Email == "DemoPM@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoPM@mailinator.com",
                    Email = "DemoPM@mailinator.com",
                    FirstName = "Demo",
                    LastName = "ProjectManager",
                    DisplayName = "Project Manager"
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoPM1@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoPM1@mailinator.com",
                    Email = "DemoPM1@mailinator.com",
                    FirstName = "Steph",
                    LastName = "Curry",
                    DisplayName = "Steph Curry"
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoPM2@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoPM2@mailinator.com",
                    Email = "DemoPM2@mailinator.com",
                    FirstName = "Kevin",
                    LastName = "Durant",
                    DisplayName = " KD "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoPM3@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoPM3@mailinator.com",
                    Email = "DemoPM3@mailinator.com",
                    FirstName = "Klay",
                    LastName = "Thompson",
                    DisplayName = " Klay Thompson "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoPM4@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoPM4@mailinator.com",
                    Email = "DemoPM4@mailinator.com",
                    FirstName = "Andre",
                    LastName = "Iguodala ",
                    DisplayName = "Andre Iguodala"
                }, "DemoUserPassword");
            }


            //Demo Developers ------------------------------------------------
            if (!context.Users.Any(u => u.Email == "DemoDev@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoDev@mailinator.com",
                    Email = "DemoDev@mailinator.com",
                    FirstName = "Demo",
                    LastName = "Developer",
                    DisplayName = " Demo Developer"
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoDev1@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoDev1@mailinator.com",
                    Email = "DemoDev1@mailinator.com",
                    FirstName = "Cam",
                    LastName = "Newton",
                    DisplayName = " Cam Newton "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoDev2@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoDev2@mailinator.com",
                    Email = "DemoDev2@mailinator.com",
                    FirstName = "Steve",
                    LastName = "Smith Sr.",
                    DisplayName = " Steve Smith Sr."
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoDev3@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoDev3@mailinator.com",
                    Email = "DemoDev3@mailinator.com",
                    FirstName = "Greg",
                    LastName = "Olsen",
                    DisplayName = " Greg Olsen "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoDev4@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoDev4@mailinator.com",
                    Email = "DemoDev4@mailinator.com",
                    FirstName = " Thomas ",
                    LastName = " Davis ",
                    DisplayName = " Thomas Davis "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoDev5@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoDev5@mailinator.com",
                    Email = "DemoDev5@mailinator.com",
                    FirstName = "Mushin",
                    LastName = " Muhammad ",
                    DisplayName = " Mushin Muhammad "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoDev6@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoDev6@mailinator.com",
                    Email = "DemoDev6@mailinator.com",
                    FirstName = " Mike ",
                    LastName = " Tolbert ",
                    DisplayName = " Mike Tolbert "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoDev7@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoDev7@mailinator.com",
                    Email = "DemoDev7@mailinator.com",
                    FirstName = " James ",
                    LastName = " Bradberry ",
                    DisplayName = " James Bradberry "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoDev8@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoDev8@mailinator.com",
                    Email = "DemoDev8@mailinator.com",
                    FirstName = " Josh ",
                    LastName = " Norman ",
                    DisplayName = " Josh Norman "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoDev9@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoDev9@mailinator.com",
                    Email = "DemoDev9@mailinator.com",
                    FirstName = " Zion ",
                    LastName = " Williamson ",
                    DisplayName = " Zion Williamson "
                }, "DemoUserPassword");
            }

            //if (!context.Users.Any(u => u.Email == "DemoDev@mailinator.com"))
            //{
            //    userManager.Create(new ApplicationUser
            //    {
            //        UserName = "DemoDev@mailinator.com",
            //        Email = "DemoDev@mailinator.com",
            //        FirstName = "Demo",
            //        LastName = "Developer",
            //        DisplayName = " Demo Developer"
            //    }, "DemoUserPassword");
            //}


            //Demo Submitters -------------------------------------------------------
            if (!context.Users.Any(u => u.Email == "DemoSub@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoSub@mailinator.com",
                    Email = "DemoSub@mailinator.com",
                    FirstName = " Tom ",
                    LastName = " Brady ",
                    DisplayName = " Tom Brady "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoSub1@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoSub1@mailinator.com",
                    Email = "DemoSub1@mailinator.com",
                    FirstName = " Richard ",
                    LastName = " Sherman ",
                    DisplayName = " Richard Sherman "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoSub2@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoSub2@mailinator.com",
                    Email = "DemoSub2@mailinator.com",
                    FirstName = " Christian ",
                    LastName = " McCaffery ",
                    DisplayName = " Christian McCaffery "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoSub3@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoSub3@mailinator.com",
                    Email = "DemoSub3@mailinator.com",
                    FirstName = " Kyrie ",
                    LastName = " Irving ",
                    DisplayName = " Kyrie Irving "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoSub4@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoSub4@mailinator.com",
                    Email = "DemoSub4@mailinator.com",
                    FirstName = " Kemba ",
                    LastName = " Walker ",
                    DisplayName = " Kemba Walker "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoSub5@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoSub5@mailinator.com",
                    Email = "DemoSub5@mailinator.com",
                    FirstName = " Grayson ",
                    LastName = " Allen ",
                    DisplayName = "Grayson Allen"
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoSub6@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoSub6@mailinator.com",
                    Email = "DemoSub6@mailinator.com",
                    FirstName = " Dj ",
                    LastName = " Moore ",
                    DisplayName = " Dj Moore"
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoSub7@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoSub7@mailinator.com",
                    Email = "DemoSub7@mailinator.com",
                    FirstName = " Trey ",
                    LastName = " Jones ",
                    DisplayName = " Trey Jones "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoSub8@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoSub8@mailinator.com",
                    Email = "DemoSub8@mailinator.com",
                    FirstName = " Tyus ",
                    LastName = " Jones ",
                    DisplayName = " Tyus Jones "
                }, "DemoUserPassword");
            }

            if (!context.Users.Any(u => u.Email == "DemoSub9@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "DemoSub9@mailinator.com",
                    Email = "DemoSub9@mailinator.com",
                    FirstName = " Michael ",
                    LastName = " Jordan ",
                    DisplayName = " Michael Jordan "
                }, "DemoUserPassword");
            }


            // Seeding users to admin manager role

            var adminId = userManager.FindByEmail("Bbeck7412@gmail.com").Id;
            userManager.AddToRole(adminId, "Admin");

            var demoAdmin = userManager.FindByEmail("DemoAdmin@mailinator.com").Id;
            userManager.AddToRole(demoAdmin, "Administrator");


            // Seeding users to project manager role
            var demoPM = userManager.FindByEmail("DemoPM@mailinator.com").Id;
            userManager.AddToRole(demoPM, "ProjectManager");

            var demoPM1 = userManager.FindByEmail("DemoPM1@mailinator.com").Id;
            userManager.AddToRole(demoPM1, "ProjectManager");

            var demoPM2 = userManager.FindByEmail("DemoPM2@mailinator.com").Id;
            userManager.AddToRole(demoPM2, "ProjectManager");

            var demoPM3 = userManager.FindByEmail("DemoPM3@mailinator.com").Id;
            userManager.AddToRole(demoPM3, "ProjectManager");

            var demoPM4 = userManager.FindByEmail("DemoPM4@mailinator.com").Id;
            userManager.AddToRole(demoPM4, "ProjectManager");


            // Seeding users to developers role
            var demoDev = userManager.FindByEmail("DemoDev@mailinator.com").Id;
            userManager.AddToRole(demoDev, "Developer");

            var demoDev1 = userManager.FindByEmail("DemoDev1@mailinator.com").Id;
            userManager.AddToRole(demoDev1, "Developer");

            var demoDev2 = userManager.FindByEmail("DemoDev2@mailinator.com").Id;
            userManager.AddToRole(demoDev2, "Developer");

            var demoDev3 = userManager.FindByEmail("DemoDev3@mailinator.com").Id;
            userManager.AddToRole(demoDev3, "Developer");

            var demoDev4 = userManager.FindByEmail("DemoDev4@mailinator.com").Id;
            userManager.AddToRole(demoDev4, "Developer");

            var demoDev5 = userManager.FindByEmail("DemoDev5@mailinator.com").Id;
            userManager.AddToRole(demoDev5, "Developer");

            var demoDev6 = userManager.FindByEmail("DemoDev6@mailinator.com").Id;
            userManager.AddToRole(demoDev6, "Developer");

            var demoDev7 = userManager.FindByEmail("DemoDev7@mailinator.com").Id;
            userManager.AddToRole(demoDev7, "Developer");

            var demoDev8 = userManager.FindByEmail("DemoDev8@mailinator.com").Id;
            userManager.AddToRole(demoDev8, "Developer");

            var demoDev9 = userManager.FindByEmail("DemoDev9@mailinator.com").Id;
            userManager.AddToRole(demoDev9, "Developer");


            // Seeding users to submitter role
            var demoSub = userManager.FindByEmail("DemoSub@mailinator.com").Id;
            userManager.AddToRole(demoSub, "Submitter");

            var demoSub1 = userManager.FindByEmail("DemoSub1@mailinator.com").Id;
            userManager.AddToRole(demoSub1, "Submitter");

            var demoSub2 = userManager.FindByEmail("DemoSub2@mailinator.com").Id;
            userManager.AddToRole(demoSub2, "Submitter");

            var demoSub3 = userManager.FindByEmail("DemoSub3@mailinator.com").Id;
            userManager.AddToRole(demoSub3, "Submitter");

            var demoSub4 = userManager.FindByEmail("DemoSub4@mailinator.com").Id;
            userManager.AddToRole(demoSub4, "Submitter");

            var demoSub5 = userManager.FindByEmail("DemoSub5@mailinator.com").Id;
            userManager.AddToRole(demoSub5, "Submitter");

            var demoSub6 = userManager.FindByEmail("DemoSub6@mailinator.com").Id;
            userManager.AddToRole(demoSub6, "Submitter");

            var demoSub7 = userManager.FindByEmail("DemoSub7@mailinator.com").Id;
            userManager.AddToRole(demoSub7, "Submitter");

            var demoSub8 = userManager.FindByEmail("DemoSub8@mailinator.com").Id;
            userManager.AddToRole(demoSub8, "Submitter");

            var demoSub9 = userManager.FindByEmail("DemoSub9@mailinator.com").Id;
            userManager.AddToRole(demoSub9, "Submitter");






            context.Projects.AddOrUpdate(
            p => p.Name,
                new Project { Name = "Brandon's Portfolio", Description = "My Portfolio website", Created = DateTime.Now },
                new Project { Name = "Brandon's Blog", Description = "My Blog Project Using MVC & C#", Created = DateTime.Now },
                new Project { Name = "Brandon's Bug Tracker", Description = "My Bug Tracker Project Using MVC & C#", Created = DateTime.Now },
                new Project { Name = "Financial Portal", Description = "Financial portal Project Using MVC & C#", Created = DateTime.Now },
                new Project { Name = "Xamarin Mobile Project", Description = "My Xamarin Project", Created = DateTime.Now }
                );


            context.TicketPriorities.AddOrUpdate(
                p => p.Name,
                new TicketPriority { Name = "Low Priority", Description = "Application or personal procedure unusable, where a workaround is available or a repair is possible." },
                new TicketPriority { Name = "Normal", Description = "Non-critical function or procedure, unusable or hard to use having an operational impact, but with no direct impact on services availability. A workaround is available." },
                new TicketPriority { Name = "Important", Description = "Critical functionality or network access interrupted, degraded or unusable, having a severe impact on services availability. No acceptable alternative is possible." },
                new TicketPriority { Name = "Critical", Description = "Interruption making a critical functionality inaccessible or a complete network interruption causing a severe impact on services availability. There is no possible alternative." }
                );

            context.TicketTypes.AddOrUpdate(
                p => p.Name,
                new TicketType { Name = "Bugs", Description = "A bug has been reported in the software." },
                new TicketType { Name = "Feature Request", Description = "A client has requested a new feature to be implemented." },
                new TicketType { Name = "Technical Support", Description = "A client needs assistance using software features." }
                );

            context.TicketStatus.AddOrUpdate(
                p => p.Name,
                new TicketStatus { Name = "New", Description = "Ticket creation successful but has not been assigned to a user." },
                new TicketStatus { Name = "Open", Description = "Ticket has been assigned to a user who is working to resolve the issue." },
                new TicketStatus { Name = "On-Hold", Description = "Ticket awaiting more information from the requesting user or third party assistance." },
                new TicketStatus { Name = "Closed", Description = "Ticket has been canceled due to accidental creation or client request." },
                new TicketStatus { Name = "Resolved", Description = "Ticket has been completed by assigned user." }
                );

            //context.Tickets.AddOrUpdate(
            //    t => t.Title,
            //    new Ticket { Title = "Random Logout", Description = "I keep getting randomly logged out for no reason.", Created = DateTime.Now}
            //    );


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

    }
}
