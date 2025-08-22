using FluentValidation.TestHelper;
using NetBoilerplate.Application.Validation;
using NetBoilerplate.Domain.Entities;
using Xunit;

namespace NetBoilerplate.Application.Tests
{
    public class ItemValidatorTests
    {
        private readonly ItemValidator _validator;

        public ItemValidatorTests()
        {
            _validator = new ItemValidator();
        }

        [Fact]
        public void Validate_ShouldPass_WhenItemIsValid()
        {
            // Arrange
            var item = new Item
            {
                Name = "Valid Item",
                Price = 10.0m
            };

            // Act
            var result = _validator.TestValidate(item);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_ShouldFail_WhenNameIsEmpty()
        {
            // Arrange
            var item = new Item
            {
                Name = "",
                Price = 10.0m
            };

            // Act
            var result = _validator.TestValidate(item);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage("Name is required.");
        }

        [Fact]
        public void Validate_ShouldFail_WhenNameExceedsMaxLength()
        {
            // Arrange
            var item = new Item
            {
                Name = new string('a', 101), // 101 characters
                Price = 10.0m
            };

            // Act
            var result = _validator.TestValidate(item);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage("Name cannot exceed 100 characters.");
        }

        [Fact]
        public void Validate_ShouldFail_WhenPriceIsZero()
        {
            // Arrange
            var item = new Item
            {
                Name = "Valid Item",
                Price = 0.0m
            };

            // Act
            var result = _validator.TestValidate(item);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Price)
                .WithErrorMessage("Price must be greater than zero.");
        }
    }
}
