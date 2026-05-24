using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Cinema.Domain
{
    public class RegisteredUser : User
    {
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();

        public override string GetRole() => "RegisteredUser";

        public Ticket BuyTicket(Session session, Seat seat)
        {
            if (!session.IsSeatAvailable(seat)) return null;
            var ticket = new Ticket
            {
                Id = Admin.Tickets.Count + 1,
                Session = session,
                Seat = seat,
                RegisteredUser = this,
                BuyerName = this.Name,
                Price = session.BasePrice,
                PurchaseDateTime = DateTime.Now,
                QrCode = Ticket.GenerateQrCode()
            };
            session.BookSeat(seat);
            Admin.Tickets.Add(ticket);
            Tickets.Add(ticket);
            return ticket;
        }

        public List<Ticket> GetPurchaseHistory() => Tickets;
    }
}