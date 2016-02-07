using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecruitYourselfApplication.Web.Startup))]
namespace RecruitYourselfApplication.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
