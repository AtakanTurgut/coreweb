using BL;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
    public class PostController : Controller
    {
        PostManager postManager = new PostManager();

        public IActionResult Index()
        {
            return View(postManager.GetAll());
        }

        public IActionResult Detail(int id)
        {
            return View(postManager.Find(id));
        }
    }
}
