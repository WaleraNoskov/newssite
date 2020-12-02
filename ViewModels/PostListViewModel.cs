using System.Threading;
using System.Collections.Generic;
using newsSite.Models;

namespace newsSite.ViewModels
{
    public class PostListViewModel
    {
        public int PostsCount { get; set; }
        public List<BlogPost> Posts { get; set; }
        public PostListViewModel(List<BlogPost> list, int count)
        {
            this.Posts = list;
            this.PostsCount = count;
        }
    }
}