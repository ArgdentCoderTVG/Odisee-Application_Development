using Demo_Entity_Framework.Data;
using Demo_Entity_Framework.Data.Entities;
using Demo_Entity_Framework.Models;
using Demo_Entity_Framework.Service;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Entity_Framework.Controllers
{
    public class BlogController : Controller
    {
        private BlogService service = new BlogService();
        public IActionResult Index()
        {
            return View(service.GetAllPosts());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                //post bewaren in databank
                //redirect (POST-REDIRECT-GET)
                service.SavePost(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            EditPostViewModel model = service.GetPostForEdit(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                //update uitvoeren
                //redirect (POST/REDIRECT/GET)
                service.UpdatePost(id, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int id)
        {
            PostDetailsViewModel model = service.GetPostDetails(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(int id, PostDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                service.AddComment(id, model);
                return RedirectToAction("Details", new { id = id });
            }

            return View(model);
        }
    }
}
