using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Domain.Entities;
using TestApp.Domain.Interfaces;
using TestApp.Application.Interfaces;

namespace TestApp.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public Task<IEnumerable<Item>> GetAllAsync() => _itemRepository.GetAllAsync();
        public Task<Item> GetByIdAsync(Guid id) => _itemRepository.GetByIdAsync(id);
        public Task AddAsync(Item item) => _itemRepository.AddAsync(item);
        public Task UpdateAsync(Item item) => _itemRepository.UpdateAsync(item);
        public Task DeleteAsync(Guid id) => _itemRepository.DeleteAsync(id);
    }
}
