using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Models;

namespace Epsic_Cave_A_Vin_Ethan.Repositories
{
    public interface IBottlesRepository
    {
        // Task<int> AddCharacterToBottle(int userId, int characterId);
        Task<Bottle> CreateAsync(CreateBottleDto bottleToCreate);
        Task<int> Delete(int id);
        Task<bool> ExistsById(int id);
        Task<bool> ExistsByName(string name);
        Task<bool> ExistsByNameAndDate(string name, DateTime date);
        Task<BottleDetailViewModel> GetSingle(int id);

        // Task<int> RemoveCharacterFromBottle(int userId, int characterId);
        Task<List<BottleDetailViewModel>> Search(string name);
        Task<Bottle> UpdateAsync(int id, UpdateBottleDto bottleToUpdate);
    }
}