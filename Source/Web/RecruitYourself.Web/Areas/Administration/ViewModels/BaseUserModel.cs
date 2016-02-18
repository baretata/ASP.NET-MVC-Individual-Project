using System.ComponentModel.DataAnnotations;

namespace RecruitYourself.Web.Areas.Administration.ViewModels
{
    public class BaseUserModel : BaseAdministrationModel
    {
        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

    }
}