namespace RecruitYourself.Web
{
    using System.Web.Mvc;

    public static class ViewEngineConfig
    {
        public static void RegisterRazorViewEngine()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
