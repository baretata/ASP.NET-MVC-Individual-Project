﻿namespace RecruitYourself.Web.Areas.Article.ViewModels
{
    using System;

    using AutoMapper;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Web;
    using RecruitYourself.Services.Web.Contracts;
    using RecruitYourself.Web.Infrastructure.Mapping;

    public class ArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        private IIdentifierProvider identifier;

        public ArticleViewModel()
        {
            this.identifier = new IdentifierProvider();
        }

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
                return this.identifier.EncodeId(this.Id);
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
