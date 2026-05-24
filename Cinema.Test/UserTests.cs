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
    public class UserTests
    {
        [TestMethod]
        public void Admin_GetRole_ReturnsAdmin()
        {
            // Arrange
            var admin = new Admin();

            // Act
            var role = admin.GetRole();

            // Assert
            Assert.AreEqual("Admin", role);
        }

        [TestMethod]
        public void Guest_CanBuyTicket_ReturnsTrue()
        {
            // Arrange
            var guest = new Guest();
            var session = new Session();

            // Act
            var canBuy = guest.CanBuyTicket(session);

            // Assert
            Assert.IsTrue(canBuy);
        }

        [TestMethod]
        public void RegisteredUser_GetRole_ReturnsRegisteredUser()
        {
            // Arrange
            var user = new RegisteredUser();

            // Act
            var role = user.GetRole();

            // Assert
            Assert.AreEqual("RegisteredUser", role);
        }
    }
}