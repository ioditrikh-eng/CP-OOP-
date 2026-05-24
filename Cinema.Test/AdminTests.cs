using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema.Domain;
using System.Linq;

namespace Cinema.Tests
{
    [TestClass]
    public class AdminTests
    {
        [TestInitialize]
        public void Setup()
        {
            
            Admin.Movies.Clear();
            Admin.Halls.Clear();
            Admin.Sessions.Clear();
            Admin.Tickets.Clear();
        }

        [TestMethod]
        public void Admin_AddMovie_ValidMovie_ReturnsTrue()
        {
            var admin = new Admin();
            var movie = new Movie { Title = "Dune", Genre = "Sci-Fi", DurationMinutes = 155 };
            var result = admin.AddMovie(movie);
            Assert.IsTrue(result);
            Assert.AreEqual(1, Admin.Movies.Count);
        }

        [TestMethod]
        public void Admin_AddMovie_DuplicateTitle_ReturnsFalse()
        {
            var admin = new Admin();
            var movie1 = new Movie { Title = "Dune", Genre = "Sci-Fi", DurationMinutes = 155 };
            var movie2 = new Movie { Title = "Dune", Genre = "Action", DurationMinutes = 120 };
            admin.AddMovie(movie1);
            var result = admin.AddMovie(movie2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Admin_DeleteMovie_WithoutSessions_ReturnsTrue()
        {
            var admin = new Admin();
            var movie = new Movie { Title = "Dune", Genre = "Sci-Fi", DurationMinutes = 155 };
            admin.AddMovie(movie);
            var result = admin.DeleteMovie(movie.Id);
            Assert.IsTrue(result);
            Assert.AreEqual(0, Admin.Movies.Count);
        }

        [TestMethod]
        public void Admin_AddSession_ValidSession_ReturnsTrue()
        {
            var admin = new Admin();
            var hall = new Hall { Number = 1, Rows = 5, SeatsPerRow = 10 };
            admin.AddHall(hall);
            var movie = new Movie { Title = "Dune" };
            admin.AddMovie(movie);
            var session = new Session { Movie = movie, Hall = hall, DateTime = System.DateTime.Now.AddDays(1), BasePrice = 200 };
            var result = admin.AddSession(session);
            Assert.IsTrue(result);
            Assert.AreEqual(1, Admin.Sessions.Count);
        }

        [TestMethod]
        public void Admin_AddSession_PastDate_ReturnsFalse()
        {
            var admin = new Admin();
            var hall = new Hall { Number = 1, Rows = 5, SeatsPerRow = 10 };
            admin.AddHall(hall);
            var movie = new Movie { Title = "Dune" };
            admin.AddMovie(movie);
            var session = new Session { Movie = movie, Hall = hall, DateTime = System.DateTime.Now.AddDays(-1), BasePrice = 200 };
            var result = admin.AddSession(session);
            Assert.IsFalse(result);
        }
    }
}