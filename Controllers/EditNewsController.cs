using System.Linq;
using Microsoft.AspNetCore.Mvc;
using newsSite.DAL.Repositories;
using newsSite.Models;
using newsSite.ViewModels;

namespace newsSite.Controllers
{
    [Route("post/[action]")]
    public class EditNewsController : Controller
    {
        protected IRepositoryBase<BlogPost> postsRepositoy;
        protected IRepositoryBase<Category> categoriesRepository;

        public EditNewsController(IRepositoryBase<BlogPost> postsRepository, IRepositoryBase<Category> categoriesRepository)
        {
            this.postsRepositoy = postsRepository;
            this.categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        [ActionName("AddOrEdit")]
        public IActionResult AddOrEdit(bool needEdit, int id)
        {
            if (needEdit == true)
            {
                var model = new EditViewModel() { NeedEdit = true, Categories = categoriesRepository.Query(x => x.Id >= 0).ToList() };
                model.DTO = postsRepositoy.Find(id);
                return View("AddOrEdit", model);
            }
            else
            {
                return View(new EditViewModel() { Categories = categoriesRepository.Query(x => x.Id >= 0).ToList() });
            }
        }

        [HttpPost]
        [ActionName("AddOrEdit")]
        public IActionResult AddOrEdit(EditViewModel model, bool needEdit)
        {
            model.Succes = true;
            var blogPost = model.DTO;
            if (needEdit == true)
            {
                postsRepositoy.Update(blogPost);
                return View(model);
            }
            else
            {
                postsRepositoy.Insert(blogPost);
                return View(model);
            }
        }

        [HttpGet]
        [ActionName("Post")]
        public IActionResult Post(int id)
        {
            return View("Show", postsRepositoy.Find(id));
        }
    }
}