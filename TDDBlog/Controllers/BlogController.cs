using System.Collections.Generic;
using System.Web.Mvc;
using TDDBlog.Models;

namespace TDDBlog.Controllers
{
    public class BlogController: Controller
    {
        private Models.IBlogsRepository iBlogsRepository;

        public BlogController(Models.IBlogsRepository iBlogsRepository)
        {
            // TODO: Complete member initialization
            this.iBlogsRepository = iBlogsRepository;
        }


        public ViewResult Index()
        {
            IEnumerable<BlogEntry> blogEntries = iBlogsRepository.GetAllBlogEntries();
            foreach (BlogEntry blogEntry in blogEntries)
            {
                blogEntry.Url = blogEntry.Title.
                    Replace("'", string.Empty).
                    Replace("!", string.Empty).
                    Replace(" ", "-").
                    ToLower();
            }
            return View(blogEntries);
        }
    }
}
