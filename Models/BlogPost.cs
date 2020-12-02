using System;

namespace newsSite.Models
{
    public class BlogPost : EntityBase
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public virtual Category Сategory { get; set; }

        public BlogPost()
        {
            this.Date = DateTime.Now;
        }
    }
}