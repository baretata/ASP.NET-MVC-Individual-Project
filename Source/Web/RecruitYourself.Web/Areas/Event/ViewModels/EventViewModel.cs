namespace RecruitYourself.Web.Areas.Event.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Web;
    using RecruitYourself.Services.Web.Contracts;
    using RecruitYourself.Web.Infrastructure.Mapping;

    public class EventViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        private IIdentifierProvider identifier;

        public EventViewModel()
        {
            this.identifier = new IdentifierProvider();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Category { get; set; }

        public string Creator { get; set; }

        public string Image { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<string> Participants { get; set; }

        public string EncodedId
        {
            get
            {
                return this.identifier.EncodeId(this.Id);
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(x => x.Creator, opt => opt.MapFrom(x => x.Creator.UserName))
                .ForMember(x => x.Image, opt => opt.MapFrom(x => x.Creator.Image))
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name))
                .ForMember(x => x.Participants, opt => opt.MapFrom(x => x.Participants.Select(p => p.UserName)));
        }
    }
}
