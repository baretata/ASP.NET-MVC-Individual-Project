namespace RecruitYourself.Web.Areas.Article.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using RecruitYourself.Common.Constants;
    using RecruitYourself.Data.Models;
    using RecruitYourself.Web.Infrastructure.Mapping;

    public class ArticleInputModel : IMapTo<Article>
    {
        [Required]
        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DatabaseModelsConstants.ContentMaxLength)]
        public string Content { get; set; }
    }
}
