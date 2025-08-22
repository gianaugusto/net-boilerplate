using Moq;
using NetBoilerplate.Application.Services;
using NetBoilerplate.Domain.Entities;
using NetBoilerplate.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NetBoilerplate.Application.Tests
{
    public class ItemServiceTests
    {
        private readonly Mock<IItemRepository> _itemRepositoryMock;
        private readonly ItemService _itemService;

        public ItemServiceTests()
        {
            _itemRepositoryMock = new Mock<IItemRepository>();
            _itemService = new ItemService(_itemRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllItems()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item { Id = Guid.NewGuid(), Name = "Item1" },
                new Item { Id = Guid.NewGuid(), Name = "Item2" }
            };
            _itemRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(items);

            // Act
            var result = await _itemService.GetAllAsync();

            // Assert
            Assert.Equal(items, result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsItem()
        {
            // Arrange
            var itemId = Guid.NewGuid();
            var item = new Item { Id = itemId, Name = "Test Item" };
            _itemRepositoryMock.Setup(repo => repo.GetByIdAsync(itemId)).ReturnsAsync(item);

            // Act
            var result = await _itemService.GetByIdAsync(itemId);

            // Assert
            Assert.Equal(item, result);
        }

        [Fact]
        public async Task AddAsync_AddsItem()
        {
            // Arrange
            var item = new Item { Id = Guid.NewGuid(), Name = "New Item" };

            // Act
            await _itemService.AddAsync(item);

            // Assert
            _itemRepositoryMock.Verify(repo => repo.AddAsync(item), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesItem()
        {
            // Arrange
            var item = new Item { Id = Guid.NewGuid(), Name = "Updated Item" };

            // Act
            await _itemService.UpdateAsync(item);

            // Assert
            _itemRepositoryMock.Verify(repo => repo.UpdateAsync(item), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_DeletesItem()
        {
            // Arrange
            var itemId = Guid.NewGuid();

            // Act
            await _itemService.DeleteAsync(itemId);

            // Assert
            _itemRepositoryMock.Verify(repo => repo.DeleteAsync(itemId), Times.Once);
        }
    }
}
