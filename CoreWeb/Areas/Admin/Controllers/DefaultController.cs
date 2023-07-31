
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class DefaultController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        public IActionResult Index()
        {
            return View(db.Contacts.ToList());
        }
    }
}
