using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema.Domain;
using System;

namespace Cinema.Tests
{
    [TestClass]
    public class TicketTests
    {
        [TestMethod]
        public void Ticket_GenerateQrCode_ReturnsNonEmptyString()
        {
            var qr = Ticket.GenerateQrCode();
            Assert.IsNotNull(qr);
            Assert.IsTrue(qr.Length > 0);
        }

        [TestMethod]
        public void Ticket_GetTicketInfo_ContainsMovieTitle()
        {
            var movie = new Movie { Title = "Avatar" };
            var session = new Session { Movie = movie, DateTime = DateTime.Now, BasePrice = 150 };
            var seat = new Seat { Row = 3, Number = 5 };
            var ticket = new Ticket
            {
                Session = session,
                Seat = seat,
                Price = 150,
                BuyerName = "Test"
            };
            var info = ticket.GetTicketInfo();
            Assert.IsTrue(info.Contains("Avatar"));
        }
    }
}
