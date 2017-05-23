using DotNetBlog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DotNetBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Blog
        public ActionResult Index()
        {
            var posts = _context.Posts.Where(p => p.Published).OrderBy(g => g.PostedOn).ToList();

            var PostVM = new List<BlogViewModel>();

            foreach (var post in posts)
            {
                var newPost = new BlogViewModel()
                {
                    ID = post.Id,
                    PostedOn = post.PostedOn,
                    Category = getCategories(post.Id),
                    ShortDescription = post.ShortDescription,
                    ImagePreview = post.ImagePreview
                };

                PostVM.Add(newPost);
            }

            return View(PostVM);
        }

        public ActionResult Post(string id)
        {

            return View();
        }

        private List<string> getCategories(string postId)
        {

            var categoriesForPost = _context.PostCategories.Where(pc => pc.PostId == postId).ToList();
            var listCategories = new List<string>();
            foreach (var postCategory in categoriesForPost)
            {
                listCategories.Add(_context.Categories.Single(c => c.Id == postCategory.CategoryId).Name);
            }

            return listCategories;
        }
    }
}