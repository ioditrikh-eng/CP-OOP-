using Cinema.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    public class TicketsController : Controller
    {
        [HttpPost]
        public IActionResult Buy(int sessionId, int row, int number, string buyerName)
        {
            var session = Admin.Sessions.FirstOrDefault(s => s.Id == sessionId);
            if (session == null) return NotFound();

            var seat = session.Hall.Seats.FirstOrDefault(s => s.Row == row && s.Number == number);
            if (seat == null || !session.IsSeatAvailable(seat)) return BadRequest("Місце зайняте");

            var guest = new Guest();
            var ticket = guest.BuyTicketAsGuest(session, seat, buyerName);
            if (ticket == null) return BadRequest("Помилка покупки");

            return RedirectToAction("Show", new { id = ticket.Id });
        }

        public IActionResult Show(int id)
        {
            var ticket = Admin.Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }
    }
}