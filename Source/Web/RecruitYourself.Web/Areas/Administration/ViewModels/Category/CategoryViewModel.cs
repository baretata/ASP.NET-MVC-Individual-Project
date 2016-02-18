namespace RecruitYourself.Web.Areas.Administration.ViewModels.Category
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Web.Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}