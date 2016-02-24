namespace RecruitYourself.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : BaseController
    {
        public ActionResult Unauthorized()
        {
            return this.View();
        }

        public ActionResult PageNotFound()
        {
            return this.View();
        }
    }
}
