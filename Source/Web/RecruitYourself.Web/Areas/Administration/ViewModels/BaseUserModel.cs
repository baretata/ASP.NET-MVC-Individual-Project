namespace RecruitYourself.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class BaseUserModel : BaseAdministrationModel
    {
        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }
    }
}
