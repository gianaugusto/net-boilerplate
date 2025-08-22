using Microsoft.AspNetCore.Mvc;
using Moq;
using NetBoilerplate.Api.Controllers;
using NetBoilerplate.Application.Interfaces;
using NetBoilerplate.Application.Services;
using NetBoilerplate.Application.Validation;
using NetBoilerplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NetBoilerplate.Api.Tests
{
    public class ItemsControllerTests
    {
        private readonly Mock<IItemService> _itemServiceMock;
        private readonly Mock<ItemValidator> _validatorMock;
        private readonly Mock<LoggerService> _loggerServiceMock;
        private readonly ItemsController _controller;

        public ItemsControllerTests()
        {
            _itemServiceMock = new Mock<IItemService>();
            _validatorMock = new Mock<ItemValidator>();
            _loggerServiceMock = new Mock<LoggerService>();
            _controller = new ItemsController(_itemServiceMock.Object, _validatorMock.Object, _loggerServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item { Id = Guid.NewGuid(), Name = "Item1" },
                new Item { Id = Guid.NewGuid(), Name = "Item2" }
            };
            _itemServiceMock.Setup(service => service.GetAllAsync()).ReturnsAsync(items);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<ActionResult<IEnumerable<Item>>>(result);
            var returnValue = Assert.IsType<OkObjectResult>(okResult.Result);
            Assert.Equal(items, returnValue.Value);
        }

        [Fact]
        public async Task GetAll_LogsError_WhenExceptionThrown()
        {
            // Arrange
            _itemServiceMock.Setup(service => service.GetAllAsync()).Throws(new Exception("Test exception"));

            // Act
            var result = await _controller.GetAll();

            // Assert
            var errorResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, errorResult.StatusCode);
            _loggerServiceMock.Verify(logger => logger.LogError(It.IsAny<string>(), It.IsAny<Exception>()), Times.Once);
        }
    }
}
