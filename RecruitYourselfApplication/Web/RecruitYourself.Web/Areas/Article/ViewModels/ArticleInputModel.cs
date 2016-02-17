namespace RecruitYourself.Web.Areas.Article.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Infrastructure.Mapping;

    public class ArticleInputModel : IMapTo<Article>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }
    }
}
