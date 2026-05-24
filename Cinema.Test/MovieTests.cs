using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cinema.Domain;

namespace Cinema.Tests
{
    [TestClass]
    public class MovieTests
    {
        [TestMethod]
        public void Movie_Validate_ValidMovie_ReturnsTrue()
        {
            var movie = new Movie { Title = "Test", DurationMinutes = 120 };
            Assert.IsTrue(movie.Validate());
        }

        [TestMethod]
        public void Movie_Validate_EmptyTitle_ReturnsFalse()
        {
            var movie = new Movie { Title = "", DurationMinutes = 120 };
            Assert.IsFalse(movie.Validate());
        }

        [TestMethod]
        public void Movie_GetInfo_ReturnsCorrectString()
        {
            var movie = new Movie { Title = "Avatar", DurationMinutes = 162, Genre = "Fantasy" };
            var info = movie.GetInfo();
            Assert.AreEqual("Avatar (162 хв, Fantasy)", info);
        }
    }
}
