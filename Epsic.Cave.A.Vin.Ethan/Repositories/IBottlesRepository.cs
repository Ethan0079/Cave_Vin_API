using System.Collections.Generic;
using System.Threading.Tasks;
using Epsic.Cave.A.Vin.Ethan.Models;

namespace Epsic.Cave.A.Vin.Ethan.Repositories
{
    public interface IBottlesRepository
    {
        // Task<int> AddCharacterToBottle(int userId, int characterId);
        Task<Bottle> CreateAsync(CreateBottleDto bottleToCreate);
        Task<int> Delete(int id);
        Task<bool> ExistsById(int id);
        Task<bool> ExistsByName(string name);
        Task<BottleDetailViewModel> GetSingle(int id);

        // Task<int> RemoveCharacterFromBottle(int userId, int characterId);
        Task<List<BottleSummaryViewModel>> Search(string name);
        Task<Bottle> UpdateAsync(int id, UpdateBottleDto bottleToUpdate);
    }
}