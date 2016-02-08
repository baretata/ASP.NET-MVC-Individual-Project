namespace RecruitYourselfApplication.Web
{
    using System.Web.Mvc;

    public class ViewEngineConfig
    {
        public static void RegisterRazorViewEngine()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}