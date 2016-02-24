namespace RecruitYourself.Web.ViewModels.Home
{
    using AutoMapper;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Web;
    using RecruitYourself.Services.Web.Contracts;
    using RecruitYourself.Web.Infrastructure.Mapping;

    public class EventIndexViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        private IIdentifierProvider identifier;

        public EventIndexViewModel()
        {
            this.identifier = new IdentifierProvider();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

        public string EncodedId
        {
            get
            {
                return this.identifier.EncodeId(this.Id);
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Event, EventIndexViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name))
                .ForMember(x => x.Image, opt => opt.MapFrom(x => x.Creator.Image));
        }
    }
}
