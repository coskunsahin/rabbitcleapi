using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fakestoreapi;
using fakestoreapi.api.Controllers;
using fakestoreapi.application.ViewModels;
using fakestoreapi.domain.Entities;

namespace TestServices
{
   


    public class PeopleControllerTest
    {
        private readonly PeopleController _controller;
        private readonly PeopleServiceFake _service;

        public PeopleControllerTest()
        {
            _service = new PeopleServiceFake();
            _controller = new PeopleController((fakestoreapi.application.Common.Interfaces.ICurrentUserService)_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAll();

            // Assert
            var items = Assert.IsType<List<People>>(okResult);
            Assert.Equal(3, items.Count);
        }

        //[Fact]
        //public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        //{
        //    // Act
        //    var notFoundResult = _controller.GetById(newPeople);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(notFoundResult);
        //}

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            People people = new People();
            people.PeopleID = people.PeopleID
                ;

            // Act
            var okResult = _controller.GetById(people);

            // Assert
            Assert.IsType<ObjectResult>(okResult);
        }

        //[Fact]
        //public void GetById_ExistingGuidPassed_ReturnsRightItem()
        //{
        //    // Arrange
        //    var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

        //    // Act
        //    var okResult = _controller.Get(testGuid) as OkObjectResult;

        //    // Assert
        //    Assert.IsType<ShoppingItem>(okResult.Value);
        //    Assert.Equal(testGuid, (okResult.Value as ShoppingItem).Id);
        //}

        //[Fact]
        //public void Add_InvalidObjectPassed_ReturnsBadRequest()
        //{
        //    // Arrange
        //    var nameMissingItem = new ShoppingItem()
        //    {
        //        Manufacturer = "Guinness",
        //        Price = 12.00M
        //    };
        //    _controller.ModelState.AddModelError("Name", "Required");

        //    // Act
        //    var badResponse = _controller.Post(nameMissingItem);

        //    // Assert
        //    Assert.IsType<BadRequestObjectResult>(badResponse);
        //}

        //[Fact]
        //public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        //{
        //    // Arrange
        //    ShoppingItem testItem = new ShoppingItem()
        //    {
        //        Name = "Guinness Original 6 Pack",
        //        Manufacturer = "Guinness",
        //        Price = 12.00M
        //    };

        //    // Act
        //    var createdResponse = _controller.Post(testItem);

        //    // Assert
        //    Assert.IsType<CreatedAtActionResult>(createdResponse);
        //}

        //[Fact]
        //public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        //{
        //    // Arrange
        //    var testItem = new ShoppingItem()
        //    {
        //        Name = "Guinness Original 6 Pack",
        //        Manufacturer = "Guinness",
        //        Price = 12.00M
        //    };

        //    // Act
        //    var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
        //    var item = createdResponse.Value as ShoppingItem;

        //    // Assert
        //    Assert.IsType<ShoppingItem>(item);
        //    Assert.Equal("Guinness Original 6 Pack", item.Name);
        //}

        //[Fact]
        //public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        //{
        //    // Arrange
        //    var notExistingGuid = Guid.NewGuid();

        //    // Act
        //    var badResponse = _controller.Remove(notExistingGuid);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(badResponse);
        //}

        //[Fact]
        //public void Remove_ExistingGuidPassed_ReturnsNoContentResult()
        //{
        //    // Arrange
        //    var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

        //    // Act
        //    var noContentResponse = _controller.Remove(existingGuid);

        //    // Assert
        //    Assert.IsType<NoContentResult>(noContentResponse);
        //}

        //[Fact]
        //public void Remove_ExistingGuidPassed_RemovesOneItem()
        //{
        //    // Arrange
        //    var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

        //    // Act
        //    var okResponse = _controller.Remove(existingGuid);

        //    // Assert
        //    Assert.Equal(2, _service.GetAllItems().Count());
        //}
    }
    }