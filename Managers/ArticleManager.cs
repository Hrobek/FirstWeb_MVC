using AutoMapper;
using FirstWeb_MVC.Interfaces;
using FirstWeb_MVC.Models;
using AspBlog.Models;

namespace FirstWeb_MVC.Managers
{
    public class ArticleManager(IArticleRepository articleRepository, IMapper mapper)
    {
        private readonly IArticleRepository articleRepository = articleRepository;
        private readonly IMapper mapper = mapper;

        public async Task<ArticleViewModel?> FindArticleById(int id)
        {
            Article? article = await articleRepository.FindById(id);
            return mapper.Map<ArticleViewModel>(article);
        }

        public async Task<List<ArticleViewModel>> GetAllArticles()
        {
            List<Article> articles = await articleRepository.GetAll();
            return mapper.Map<List<ArticleViewModel>>(articles);
        }

        public async Task<ArticleViewModel?> AddArticle(ArticleViewModel articleViewModel)
        {
            Article article = mapper.Map<Article>(articleViewModel);
            Article addedArticle = await articleRepository.Insert(article);
            return mapper.Map<ArticleViewModel>(addedArticle);
        }

        public async Task<ArticleViewModel?> UpdateArticle(ArticleViewModel articleViewModel)
        {
            Article article = mapper.Map<Article>(articleViewModel);

            try
            {
                Article updatedArticle = await articleRepository.Update(article);
                return mapper.Map<ArticleViewModel>(updatedArticle);
            }
            catch (InvalidOperationException)
            {
                if (!await articleRepository.ExistsWithId(article.Id))
                    return null;

                throw;
            }
        }

        public async Task RemoveArticleWithId(int id)
        {
            Article? article = await articleRepository.FindById(id);

            if (article is not null)
                await articleRepository.Delete(article);
        }
    }
} 
