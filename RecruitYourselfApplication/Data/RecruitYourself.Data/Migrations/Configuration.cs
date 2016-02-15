namespace RecruitYourself.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using RecruitYourself.Common.Constants;
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private static Random randomGenerator = new Random();

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
        
        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == RoleConstants.AdminRoleConstant))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = RoleConstants.AdminRoleConstant };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User
                {
                    UserName = "admin",
                    Description = "Administrator of the application.",
                    CreatedOn = DateTime.UtcNow,
                };

                manager.Create(user, "admin123");
                manager.AddToRole(user.Id, RoleConstants.AdminRoleConstant);
            }

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new List<Category>();

            for (int i = 0; i < 20; i++)
            {
                var category = new Category
                {
                    Name = $"Category{i}"
                };

                categories.Add(category);
                context.Categories.Add(category);
            }

            var organization = new Organization
            {
                Name = "Organ",
                UserName = "organ",
                Address = "Sofia, Rakovski 20",
                Description = "Organization vision and mission description",
            };

            context.Organizations.Add(organization);

            var volunteer = new Volunteer
            {
                FirstName = "Pesho",
                LastName = "Kolev",
                UserName = "pesho",
                Age = (short)randomGenerator.Next(10, 50),
                Description = "Users dont need description"
            };

            context.Users.Add(volunteer);

            context.SaveChanges();

            var articles = new List<Article>();

            for (int i = 0; i < 10; i++)
            {
                var article = new Article
                {
                    Name = $"Article {i}",
                    Content = "Article text here",
                    CreatorId = organization.Id,
                    Creator = organization
                };

                articles.Add(article);
                context.Articles.Add(article);
            }

            context.SaveChanges();

            var events = new List<Event>();

            for (int i = 0; i < 10; i++)
            {
                var currentCategory = categories[randomGenerator.Next(0, 20)];
                var newEvent = new Event
                {
                    Name = $"Event {i}",
                    Description = "Event description insert here",
                    CategoryId = currentCategory.Id,
                    Category = currentCategory,
                    StartTime = DateTime.Now.AddDays(randomGenerator.NextDouble() * 2),
                    EndTime = DateTime.Now.AddDays(randomGenerator.NextDouble() * 7),
                };

                if (i % 2 == 1)
                {
                    newEvent.CreatorId = volunteer.Id;
                    newEvent.Creator = volunteer;
                }
                else
                {
                    newEvent.CreatorId = organization.Id;
                    newEvent.Creator = organization;
                }

                events.Add(newEvent);
                context.Events.Add(newEvent);
            }

            context.SaveChanges();
        }
    }
}
