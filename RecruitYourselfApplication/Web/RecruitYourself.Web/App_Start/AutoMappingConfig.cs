namespace RecruitYourself.Web
{
    using System.Reflection;
    using RecruitYourself.Web.Infrastructure.Mapping;

    public class AutoMappingConfig
    {
        public static void RegisterAutoMapper()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
