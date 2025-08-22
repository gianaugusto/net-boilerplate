using System.Collections.Generic;
using System.Threading.Tasks;
using NetBoilerplate.Domain.Entities;

namespace NetBoilerplate.Application.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> GetByIdAsync(Guid id);
        Task AddAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(Guid id);
    }
}
