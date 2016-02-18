namespace RecruitYourself.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using RecruitYourself.Common.Constants;
    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;
    using RecruitYourself.Web.Areas.Administration.ViewModels.Organization;
    using RecruitYourself.Web.Infrastructure.Attributes;
    using RecruitYourself.Web.Infrastructure.Mapping;

    [AuthorizeRoles(RoleConstants.AdminRoleConstant)]
    public class AllOrganizationsController : Controller
    {
        private readonly IOrganizationsService organizations;

        public AllOrganizationsController(IOrganizationsService organizations)
        {
            this.organizations = organizations;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.organizations
                .GetAll()
                .To<OrganizationViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, OrganizationInputModel organization)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.organizations.GetById(organization.Id);

                entity.UserName = organization.UserName;
                entity.Email = organization.Email;
                entity.Name = organization.Name;
                entity.Address = organization.Address;
                entity.Description = organization.Description;

                this.organizations.Save();
            }

            var organizationToDisplay = this.organizations
               .GetAll()
               .To<OrganizationViewModel>()
               .FirstOrDefault(x => x.Id == organization.Id);

            return this.Json(new[] { organizationToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, Organization organization)
        {
            this.organizations.Delete(organization.Id);

            return this.Json(new[] { organization }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
