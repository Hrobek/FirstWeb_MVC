using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspBlog.Data;
using FirstWeb_MVC.Models;
using AspBlog.Models;
using Microsoft.AspNetCore.Authorization;
using FirstWeb_MVC.Managers;

namespace AspBlog.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ArticlesController(ArticleManager articleManager) : Controller
    {
        private readonly ArticleManager articleManager = articleManager;

        // GET: Articles
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await articleManager.GetAllArticles());
        }

        // GET: Articles/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await articleManager.FindArticleById((int)id);
                
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,Title,Description")] ArticleViewModel article)
        {
            if (ModelState.IsValid)
            {
                await articleManager.AddArticle(article);
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await articleManager.FindArticleById((int)id);

            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,Title,Description")] ArticleViewModel article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updatedArticle = await articleManager.UpdateArticle(article);

                return updatedArticle is null ?
                    NotFound() :
                    RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await articleManager.FindArticleById((int)id);

;            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await articleManager.RemoveArticleWithId(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
