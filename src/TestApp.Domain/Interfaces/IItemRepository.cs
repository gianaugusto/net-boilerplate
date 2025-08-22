using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Domain.Entities;

namespace TestApp.Domain.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> GetByIdAsync(Guid id);
        Task AddAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(Guid id);
    }
}
