namespace RecruitYourself.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;
    using RecruitYourself.Web.Areas.Administration.ViewModels.Category;
    using RecruitYourself.Web.Infrastructure.Attributes;
    using RecruitYourself.Web.Infrastructure.Mapping;

    [AuthorizeRoles(RoleConstants.AdminRoleConstant)]
    public class AllCategoriesController : Controller
    {
        private readonly ICategoriesService categories;

        public AllCategoriesController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Categories_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.categories
                .GetAll()
                .To<CategoryViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Create([DataSourceRequest]DataSourceRequest request, CategoryInputModel category)
        {
            var newId = 0;
            if (this.ModelState.IsValid)
            {
                var entity = new Category
                {
                    Name = category.Name
                };

                this.categories.Add(entity);
                newId = entity.Id;
            }

            var categoryToDisplay = this.categories
                .GetAll()
                .To<CategoryViewModel>()
                .FirstOrDefault(x => x.Id == newId);

            return this.Json(new[] { categoryToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Update([DataSourceRequest]DataSourceRequest request, CategoryInputModel category)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.categories.GetById(category.Id);

                entity.Name = category.Name;

                this.categories.Save();
            }

            var categoryToDisplay = this.categories
               .GetAll()
               .To<CategoryViewModel>()
               .FirstOrDefault(x => x.Id == category.Id);

            return this.Json(new[] { categoryToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Destroy([DataSourceRequest]DataSourceRequest request, Category category)
        {
            this.categories.Delete(category.Id);

            return this.Json(new[] { category }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
