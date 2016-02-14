namespace RecruitYourself.Web
{
    using System.Data.Entity;

    using RecruitYourself.Data;
    using RecruitYourself.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
    }
}
