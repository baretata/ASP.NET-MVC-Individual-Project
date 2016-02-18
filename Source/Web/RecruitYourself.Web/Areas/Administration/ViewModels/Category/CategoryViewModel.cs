namespace RecruitYourself.Web.Areas.Administration.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Web.Infrastructure.Mapping;

    public class CategoryViewModel : BaseAdministrationModel, IMapFrom<Category>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
