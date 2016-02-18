namespace RecruitYourself.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using RecruitYourself.Data;
    using RecruitYourself.Data.Models;

    public class AdministrationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult AllVolunteers()
        {
            return this.View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Volunteer> users = this.db.Volunteers;
            DataSourceResult result = users.ToDataSourceResult(request, volunteer =>
            new
            {
                Id = volunteer.Id,
                UserName = volunteer.UserName,
                Description = volunteer.Description,
                Image = volunteer.Image,
                CreatedOn = volunteer.CreatedOn,
                ModifiedOn = volunteer.ModifiedOn,
                IsDeleted = volunteer.IsDeleted,
                DeletedOn = volunteer.DeletedOn,
                Email = volunteer.Email,
                EmailConfirmed = volunteer.EmailConfirmed,
                PasswordHash = volunteer.PasswordHash,
                SecurityStamp = volunteer.SecurityStamp,
                PhoneNumber = volunteer.PhoneNumber,
                PhoneNumberConfirmed = volunteer.PhoneNumberConfirmed,
                TwoFactorEnabled = volunteer.TwoFactorEnabled,
                LockoutEndDateUtc = volunteer.LockoutEndDateUtc,
                LockoutEnabled = volunteer.LockoutEnabled,
                AccessFailedCount = volunteer.AccessFailedCount,
                FirstName = volunteer.FirstName,
                LastName = volunteer.LastName,
                Age = volunteer.Age,
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Create([DataSourceRequest]DataSourceRequest request, Volunteer volunteer)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Volunteer
                {
                    UserName = volunteer.UserName,
                    Description = volunteer.Description,
                    Image = volunteer.Image,
                    CreatedOn = volunteer.CreatedOn,
                    ModifiedOn = volunteer.ModifiedOn,
                    IsDeleted = volunteer.IsDeleted,
                    DeletedOn = volunteer.DeletedOn,
                    Email = volunteer.Email,
                    EmailConfirmed = volunteer.EmailConfirmed,
                    PasswordHash = volunteer.PasswordHash,
                    SecurityStamp = volunteer.SecurityStamp,
                    PhoneNumber = volunteer.PhoneNumber,
                    PhoneNumberConfirmed = volunteer.PhoneNumberConfirmed,
                    TwoFactorEnabled = volunteer.TwoFactorEnabled,
                    LockoutEndDateUtc = volunteer.LockoutEndDateUtc,
                    LockoutEnabled = volunteer.LockoutEnabled,
                    AccessFailedCount = volunteer.AccessFailedCount,
                    FirstName = volunteer.FirstName,
                    LastName = volunteer.LastName,
                    Age = volunteer.Age,
                };

                this.db.Users.Add(entity);
                this.db.SaveChanges();
                volunteer.Id = entity.Id;
            }

            return this.Json(new[] { volunteer }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, Volunteer volunteer)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Volunteer
                {
                    Id = volunteer.Id,
                    UserName = volunteer.UserName,
                    Description = volunteer.Description,
                    Image = volunteer.Image,
                    CreatedOn = volunteer.CreatedOn,
                    ModifiedOn = volunteer.ModifiedOn,
                    IsDeleted = volunteer.IsDeleted,
                    DeletedOn = volunteer.DeletedOn,
                    Email = volunteer.Email,
                    EmailConfirmed = volunteer.EmailConfirmed,
                    PasswordHash = volunteer.PasswordHash,
                    SecurityStamp = volunteer.SecurityStamp,
                    PhoneNumber = volunteer.PhoneNumber,
                    PhoneNumberConfirmed = volunteer.PhoneNumberConfirmed,
                    TwoFactorEnabled = volunteer.TwoFactorEnabled,
                    LockoutEndDateUtc = volunteer.LockoutEndDateUtc,
                    LockoutEnabled = volunteer.LockoutEnabled,
                    AccessFailedCount = volunteer.AccessFailedCount,
                    FirstName = volunteer.FirstName,
                    LastName = volunteer.LastName,
                    Age = volunteer.Age,
                };

                this.db.Users.Attach(entity);
                this.db.Entry(entity).State = EntityState.Modified;
                this.db.SaveChanges();
            }

            return this.Json(new[] { volunteer }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, Volunteer volunteer)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Volunteer
                {
                    Id = volunteer.Id,
                    UserName = volunteer.UserName,
                    Description = volunteer.Description,
                    Image = volunteer.Image,
                    CreatedOn = volunteer.CreatedOn,
                    ModifiedOn = volunteer.ModifiedOn,
                    IsDeleted = volunteer.IsDeleted,
                    DeletedOn = volunteer.DeletedOn,
                    Email = volunteer.Email,
                    EmailConfirmed = volunteer.EmailConfirmed,
                    PasswordHash = volunteer.PasswordHash,
                    SecurityStamp = volunteer.SecurityStamp,
                    PhoneNumber = volunteer.PhoneNumber,
                    PhoneNumberConfirmed = volunteer.PhoneNumberConfirmed,
                    TwoFactorEnabled = volunteer.TwoFactorEnabled,
                    LockoutEndDateUtc = volunteer.LockoutEndDateUtc,
                    LockoutEnabled = volunteer.LockoutEnabled,
                    AccessFailedCount = volunteer.AccessFailedCount,
                    FirstName = volunteer.FirstName,
                    LastName = volunteer.LastName,
                    Age = volunteer.Age,
                };

                this.db.Users.Attach(entity);
                this.db.Users.Remove(entity);
                this.db.SaveChanges();
            }

            return this.Json(new[] { volunteer }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}
