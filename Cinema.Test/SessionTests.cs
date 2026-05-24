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
    public class SessionTests
    {
        [TestMethod]
        public void Session_BookSeat_SeatBecomesBooked()
        {
            var session = new Session();
            var seat = new Seat { Row = 1, Number = 1 };
            var result = session.BookSeat(seat);
            Assert.IsTrue(result);
            Assert.IsFalse(session.IsSeatAvailable(seat));
        }

        [TestMethod]
        public void Session_BookSeat_AlreadyBooked_ReturnsFalse()
        {
            var session = new Session();
            var seat = new Seat { Row = 1, Number = 1 };
            session.BookSeat(seat);
            var result = session.BookSeat(seat);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Session_CompareTo_SortsByDateTime()
        {
            var session1 = new Session { DateTime = new DateTime(2025, 6, 1, 18, 0, 0) };
            var session2 = new Session { DateTime = new DateTime(2025, 6, 1, 20, 0, 0) };
            Assert.IsTrue(session1.CompareTo(session2) < 0);
        }
    }
}