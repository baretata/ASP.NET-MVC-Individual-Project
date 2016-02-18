namespace RecruitYourself.Web.Infrastructure.Attributes
{
    using System.Web.Mvc;

    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles)
            : base()
        {
            this.Roles = string.Join(",", roles);
        }
    }
}
