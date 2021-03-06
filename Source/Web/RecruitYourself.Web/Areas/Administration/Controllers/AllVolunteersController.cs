﻿namespace RecruitYourself.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using RecruitYourself.Common.Constants;
    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;
    using RecruitYourself.Web.Areas.Administration.ViewModels.Volunteer;
    using RecruitYourself.Web.Controllers;
    using RecruitYourself.Web.Infrastructure.Attributes;
    using RecruitYourself.Web.Infrastructure.Mapping;

    [AuthorizeRoles(RoleConstants.AdminRoleConstant)]
    public class AllVolunteersController : BaseController
    {
        private readonly IVolunteersService volunteers;

        public AllVolunteersController(IVolunteersService volunteers)
        {
            this.volunteers = volunteers;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.volunteers
                .GetAll()
                .To<VolunteerViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, VolunteerInputModel volunteer)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.volunteers.GetById(volunteer.Id);

                entity.UserName = volunteer.UserName;
                entity.Email = volunteer.Email;
                entity.FirstName = volunteer.FirstName;
                entity.LastName = volunteer.LastName;
                entity.Description = volunteer.Description;
                entity.Age = volunteer.Age;

                this.volunteers.Save();
            }

            var volunteerToDisplay = this.volunteers
               .GetAll()
               .To<VolunteerViewModel>()
               .FirstOrDefault(x => x.Id == volunteer.Id);

            return this.Json(new[] { volunteerToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, Volunteer volunteer)
        {
            this.volunteers.Delete(volunteer.Id);

            return this.Json(new[] { volunteer }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
