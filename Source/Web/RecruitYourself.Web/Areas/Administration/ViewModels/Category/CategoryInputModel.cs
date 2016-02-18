namespace RecruitYourself.Web.Areas.Administration.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;

    using RecruitYourself.Common.Constants;

    public class CategoryInputModel
    {
        public int Id { get; set; }

        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string Name { get; set; }
    }
}