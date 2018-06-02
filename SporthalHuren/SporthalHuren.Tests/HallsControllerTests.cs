using System;
using System.Collections.Generic;
using System.Text;
using SporthalHuren.Models.Repository;
using SporthalHuren.Models;
using SporthalHuren.Models.Domain;
using Moq;
using Xunit;
using SporthalHuren.Controllers;
using Microsoft.AspNetCore.Mvc;
using SporthalHuren.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace SporthalHuren.Tests
{
    public class HallsControllerTests
    {
        private UnitTestSportHallContext context;
        private HallsController controller;
        public HallsControllerTests()
        {
            context = new UnitTestSportHallContext();
            controller = new HallsController(context.Repo.Object, new Mock<IActivityRepository>().Object);
        }

    
    [Fact]
    public void FilterSporthallOnCityShouldReturnOnlySporthallsInThatCity()
        {
            //Arrange
            string City = "Breda";
            
            //Act
            var result = (ViewResult)controller.Filter("", City);

            //Assert
            Assert.Equal("Filter", result.ViewName);
            Assert.Equal(2, ((SportsHallViewModel)result.ViewData.Model).SportsHalls.Count());
            Assert.False(((SportsHallViewModel)result.Model).SportsHalls.Any(a => a.City != "Breda"));
            


        }
    [Fact]
    public void FilterSportHallOnActivityShouldOnlyReturnSporthallsWithThatActivity()
        {
            //Arrange
            string Activity = "Basketbal";

            //Act
            var result = (ViewResult)controller.Filter(Activity, "");

            //Assert
            Assert.Equal("Filter", result.ViewName);
            Assert.Equal(5, ((SportsHallViewModel)result.ViewData.Model).SportsHalls.Count());
            Assert.True(((SportsHallViewModel)result.Model).SportsHalls.Any(a => a.SportsHallActivities.Any(x => x.Activity.Name.Equals("Basketbal"))));
        }
    [Fact]
    public void FilterSportHallsOnSortOrderShouldReturnSporthallsOnNameDescending()
        {
            //Arrange
            int SortBy = 1;

            //Act
            var result = (ViewResult)controller.Filter("", "", SortBy);

            //Assert
            Assert.Equal("Filter", result.ViewName);
            Assert.Equal(6, ((SportsHallViewModel)result.ViewData.Model).SportsHalls.Count());
            Assert.True(((SportsHallViewModel)result.Model).SportsHalls.ElementAt(0).Name.EndsWith("F"));

        }

    [Fact]
    public void ViewSportHallWithSpecificIDShouldReturnSporthallWithThatID()
        {
            //Arrange
            int ID = 3;

            //Act
            var result = (ViewResult)controller.Hall(ID);

            //Assert
            Assert.Equal("Hall", result.ViewName);
            Assert.True(((SportsHall)result.Model).ID == 3);
            Assert.True(((SportsHall)result.Model).Name.EndsWith("C"));
        }
    }
}
