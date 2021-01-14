using System.Collections.Generic;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Models;

namespace Epsic_Cave_A_Vin_Ethan.Services
{
    public interface ICavesService
    {
        // Task<bool> AddCharacterToCave(AddCharacterToCaveDto addCharacterToCave);
        Task<Cave> CreateAsync(CreateCaveDto bottleToCreate);
        Task<bool> Delete(int id);
        Task<List<CaveSummaryViewModel>> GetAll(string locationName);
        // Task<CaveDetailViewModel> GetSingle(int id);
        // Task<bool> RemoveCharacterFromCave(RemoveCharacterFromCaveDto removeCharacterFromCave);
        Task<Cave> UpdateAsync(int id, UpdateCaveDto bottleToUpdate);
    }
}