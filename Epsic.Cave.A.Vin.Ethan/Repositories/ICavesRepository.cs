using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Models;

namespace Epsic_Cave_A_Vin_Ethan.Repositories
{
    public interface ICavesRepository
    {
        Task<Cave> CreateAsync(CreateCaveDto caveToCreate);
        Task<int> Delete(int id);
        Task<bool> ExistsById(int id);
        Task<CaveSummaryViewModel> GetSingle(int id);
        Task<bool> ExistsByName(string locationName);
        Task<bool> ExistsByLocationAndDegree(string locationName, int degree);
        Task<List<CaveSummaryViewModel>> Search(string locationName);
        Task<Cave> UpdateAsync(int id, UpdateCaveDto caveToUpdate);
    }
}