using System.Collections.Generic;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Models;

namespace Epsic_Cave_A_Vin_Ethan.Services
{
    public interface IBottlesService
    {
        // Task<bool> AddCharacterToBottle(AddCharacterToBottleDto addCharacterToBottle);
        Task<Bottle> CreateAsync(CreateBottleDto bottleToCreate);
        Task<bool> Delete(int id);
        Task<List<BottleSummaryViewModel>> GetAll(string name);
        Task<BottleDetailViewModel> GetSingle(int id);
        // Task<bool> RemoveCharacterFromBottle(RemoveCharacterFromBottleDto removeCharacterFromBottle);
        Task<Bottle> UpdateAsync(int id, UpdateBottleDto bottleToUpdate);
    }
}