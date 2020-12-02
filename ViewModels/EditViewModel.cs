using System.Collections.Generic;
using newsSite.Models;
using newsSite.DAL.Repositories;

namespace newsSite.ViewModels
{
    public class EditViewModel
    {
        public BlogPost DTO { get; set; } = new BlogPost();
        public bool NeedEdit { get; set; }
        public bool Succes { get; set; } = false;
        public List<Category> Categories { get; set; }
    }
}