using Microsoft.EntityFrameworkCore;
using newsSite.Models;

namespace newsSite.DAL
{
    public class NewsSiteContext : DbContext
    {
        DbSet<BlogPost> BlogPosts { get; set; }
        DbSet<Category> Categories { get; set; }

        public NewsSiteContext(DbContextOptions<NewsSiteContext> options) : base(options)
        {

        }
    }
}