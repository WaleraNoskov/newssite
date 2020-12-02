using Microsoft.AspNetCore.Mvc;
using newsSite.DAL.Repositories;
using newsSite.Models;
using newsSite.ViewModels;
using System.Linq;


namespace newsSite.Controllers
{
    [Route("news/[action]")]
    public class NewsPageController : Controller
    {
        protected IRepositoryBase<BlogPost> repository { get; set; }



        public NewsPageController(IRepositoryBase<BlogPost> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ActionName("list")]
        public IActionResult GetPosts(int count)
        {
            var postsList = repository.Query(x => x.Id >= (10 * count) && x.Id <= (10 + (10 * count))).ToList();
            var postsCount = repository.Query(x => x.Id >= 0).Select(x=> x.Id).ToList().Count;
            var postsListViewmodel = new PostListViewModel(postsList, postsCount);
            return View(postsListViewmodel);
        }
    }
}