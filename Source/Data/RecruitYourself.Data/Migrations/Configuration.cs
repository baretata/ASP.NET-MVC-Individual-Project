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
                Image = "http://www.donornetworkwest.org/wp-content/uploads/2015/03/Volunteer.png"
            };

            context.Organizations.Add(organization);

            var volunteer = new Volunteer
            {
                FirstName = "Pesho",
                LastName = "Kolev",
                UserName = "pesho",
                Age = (short)randomGenerator.Next(10, 50),
                Description = "Users dont need description",
                Image = "http://www.resolve.org/assets/images/volunteer-image.jpg"
            };

            context.Users.Add(volunteer);

            context.SaveChanges();

            var articles = new List<Article>();

            for (int i = 0; i < 10; i++)
            {
                var article = new Article
                {
                    Name = $"Article {i}",
                    Content = "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful. Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but because occasionally circumstances occur in which toil and pain can procure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure?",
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
                    Description = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae.",
                    CategoryId = currentCategory.Id,
                    Category = currentCategory,
                    StartTime = DateTime.Now.AddDays(randomGenerator.NextDouble() * 2),
                    EndTime = DateTime.Now.AddDays(randomGenerator.NextDouble() * 7),
                    Participants = new List<Volunteer>() { volunteer }
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
