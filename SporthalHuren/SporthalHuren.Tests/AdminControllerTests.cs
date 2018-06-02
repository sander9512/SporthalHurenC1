using Microsoft.AspNetCore.Mvc;
using Moq;
using SporthalHuren.Controllers;
using SporthalHuren.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SporthalHuren.Tests
{
    public class AdminControllerTests
    {
        private UnitTestSportHallContext SportsHallContext;
        private UnitTestProprietorContext ProprietorContext;
        private AdminController controller;

        public AdminControllerTests()
        {
            SportsHallContext = new UnitTestSportHallContext();
            ProprietorContext = new UnitTestProprietorContext();
            controller = new AdminController(SportsHallContext.Repo.Object, ProprietorContext.Repo.Object, new Mock<IUserRepository>().Object);
        }

       // [Fact]
        public void SportsHallListTestShouldReturnViewWithSportsHalls()
        {
            //Arrange

            //Act
            //var result = (IActionResult)controller.SportsHallList(SportsHallContext.Repo.Object);
        }
    }
}
