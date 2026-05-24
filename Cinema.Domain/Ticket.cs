using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public Session Session { get; set; }
        public Seat Seat { get; set; }
        public string BuyerName { get; set; }
        public RegisteredUser RegisteredUser { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public string QrCode { get; set; }

        public static string GenerateQrCode() => Guid.NewGuid().ToString();

        public string GetTicketInfo() => $"{Session.Movie.Title} | {Session.DateTime} | {Seat.GetSeatNumber()} | {Price} грн";
    }
}
