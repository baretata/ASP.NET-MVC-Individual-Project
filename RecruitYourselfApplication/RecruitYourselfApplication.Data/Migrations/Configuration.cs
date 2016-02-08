namespace RecruitYourselfApplication.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RecruitYourselfDbContext>
    {
        private Random randomGenerator = new Random();

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RecruitYourselfDbContext context)
        {
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
                Description = "text here",
            };

            context.Organizations.Add(organization);

            var volunteer = new Volunteer
            {
                FirstName = "Pesho",
                LastName = "Kolev",
                UserName = "pesho",
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
