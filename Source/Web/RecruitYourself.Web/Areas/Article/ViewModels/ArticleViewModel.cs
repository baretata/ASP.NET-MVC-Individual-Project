namespace RecruitYourself.Web.Areas.Article.ViewModels
{
    using System;
    using AutoMapper;
    using Infrastructure.Mapping;
    using RecruitYourself.Data.Models;
    using Services.Web;
    using Services.Web.Contracts;

    public class ArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string Creator { get; set; }

        public string Image { get; set; }

        public DateTime CreatedOn { get; set; }

        public string EncodedId
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();

                return identifier.EncodeId(this.Id);
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticleViewModel>()
                .ForMember(x => x.Creator, opt => opt.MapFrom(x => x.Creator.Name))
                .ForMember(x => x.Image, opt => opt.MapFrom(x => x.Creator.Image));
        }
    }
}
