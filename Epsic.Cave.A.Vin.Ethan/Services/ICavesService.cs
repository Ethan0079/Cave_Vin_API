using System.Collections.Generic;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Models;

namespace Epsic_Cave_A_Vin_Ethan.Services
{
    public interface ICavesService
    {
        Task<Cave> CreateAsync(CreateCaveDto bottleToCreate);
        Task<bool> Delete(int id);
        Task<CaveSummaryViewModel> GetSingle(int id);
        Task<List<CaveSummaryViewModel>> GetAll(string locationName);
        Task<Cave> UpdateAsync(int id, UpdateCaveDto bottleToUpdate);
    }
}