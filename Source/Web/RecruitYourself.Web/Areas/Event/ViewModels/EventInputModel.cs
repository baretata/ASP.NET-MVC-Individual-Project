namespace RecruitYourself.Web.Areas.Event.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RecruitYourself.Common.Constants;
    using RecruitYourself.Data.Models;
    using RecruitYourself.Web.Infrastructure.Attributes;
    using RecruitYourself.Web.Infrastructure.Mapping;

    public class EventInputModel : IMapTo<Event>
    {
        [Required]
        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DatabaseModelsConstants.ContentMaxLength)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DateGreaterThan("EndTime", ErrorMessage = "Start time cannot be greater than End time!")]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<string> Participants { get; set; }
    }
}
