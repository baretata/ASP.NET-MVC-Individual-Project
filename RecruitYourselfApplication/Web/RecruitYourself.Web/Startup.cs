using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(RecruitYourself.Web.Startup))]

namespace RecruitYourself.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
