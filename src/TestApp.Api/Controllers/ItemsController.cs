using Microsoft.AspNetCore.Mvc;
using TestApp.Application.Interfaces;
using TestApp.Application.Services;
using TestApp.Application.Validation;
using TestApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ItemValidator _validator;
        private readonly LoggerService _loggerService;

        public ItemsController(IItemService itemService, ItemValidator validator, LoggerService loggerService)
        {
            _itemService = itemService;
            _validator = validator;
            _loggerService = loggerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAll()
        {
            try
            {
                var items = await _itemService.GetAllAsync();
                _loggerService.LogInformation("Items retrieved successfully.");
                return Ok(items);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("Error retrieving items.", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(Guid id)
        {
            try
            {
                var item = await _itemService.GetByIdAsync(id);
                if (item == null)
                {
                    _loggerService.LogInformation($"Item with ID {id} not found.");
                    return NotFound();
                }
                _loggerService.LogInformation($"Item with ID {id} retrieved successfully.");
                return Ok(item);
            }
            catch (Exception ex)
            {
                _loggerService.LogError($"Error retrieving item with ID {id}.", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Item item)
        {
            try
            {
                var validationResult = _validator.Validate(item);
                if (!validationResult.IsValid)
                {
                    _loggerService.LogInformation($"Validation failed for item: {validationResult.Errors}");
                    return BadRequest(validationResult.Errors);
                }

                await _itemService.AddAsync(item);
                _loggerService.LogInformation($"Item with ID {item.Id} created successfully.");
                return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("Error creating item.", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, Item item)
        {
            try
            {
                if (id != item.Id)
                {
                    _loggerService.LogInformation($"Item ID mismatch: {id} != {item.Id}");
                    return BadRequest();
                }

                var validationResult = _validator.Validate(item);
                if (!validationResult.IsValid)
                {
                    _loggerService.LogInformation($"Validation failed for item: {validationResult.Errors}");
                    return BadRequest(validationResult.Errors);
                }

                await _itemService.UpdateAsync(item);
                _loggerService.LogInformation($"Item with ID {id} updated successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerService.LogError($"Error updating item with ID {id}.", ex);
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _itemService.DeleteAsync(id);
                _loggerService.LogInformation($"Item with ID {id} deleted successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _loggerService.LogError($"Error deleting item with ID {id}.", ex);
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
