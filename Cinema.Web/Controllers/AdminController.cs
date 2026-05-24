using Cinema.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Cinema.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveToJson()
        {
            var admin = new Admin();
            admin.SaveToJson("wwwroot/data/cinema.json");
            return Content("Збережено");
        }

        [HttpPost]
        public IActionResult LoadFromJson()
        {
            var admin = new Admin();
            admin.LoadFromJson("wwwroot/data/cinema.json");
            return Content("Завантажено");
        }
    }
}