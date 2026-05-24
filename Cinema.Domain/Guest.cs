using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Cinema.Domain
{
    public class Guest : User
    {
        public override string GetRole() => "Guest";

        public Ticket BuyTicketAsGuest(Session session, Seat seat, string guestName)
        {
            if (!session.IsSeatAvailable(seat)) return null;
            var ticket = new Ticket
            {
                Id = Admin.Tickets.Count + 1,
                Session = session,
                Seat = seat,
                RegisteredUser = null,
                BuyerName = guestName,
                Price = session.BasePrice,
                PurchaseDateTime = System.DateTime.Now,
                QrCode = Ticket.GenerateQrCode()
            };
            session.BookSeat(seat);
            Admin.Tickets.Add(ticket);
            return ticket;
        }

        public RegisteredUser Register(string login, string password, string name)
        {
            var user = new RegisteredUser
            {
                Id = 100 + Admin.Halls.Count, // умовно
                Login = login,
                PasswordHash = password,
                Name = name,
                RegistrationDate = System.DateTime.Now
            };
            return user;
        }
    }
}