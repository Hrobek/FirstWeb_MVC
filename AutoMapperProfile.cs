using AspBlog.Models;
using AutoMapper;
using FirstWeb_MVC.Models;

namespace FirstWeb_MVC
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Article, ArticleViewModel>();
            CreateMap<ArticleViewModel, Article>();
        }
    }
}
