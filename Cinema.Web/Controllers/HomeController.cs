using Cinema.Domain;
using Cinema.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(Admin.Movies);
    }
}

