using Cinema.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Cinema.Web.Controllers
{
    public class SessionsController : Controller
    {
        public IActionResult Index(int movieId)
        {
            var sessions = Admin.Sessions.Where(s => s.Movie.Id == movieId).ToList();
            return View(sessions);
        }

        public IActionResult SelectSeats(int sessionId)
        {
            var session = Admin.Sessions.FirstOrDefault(s => s.Id == sessionId);
            if (session == null) return NotFound();
            return View(session);
        }
    }
}
