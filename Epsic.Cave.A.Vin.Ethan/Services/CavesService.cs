using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Exceptions;
using Epsic_Cave_A_Vin_Ethan.Models;
using Epsic_Cave_A_Vin_Ethan.Repositories;

namespace Epsic_Cave_A_Vin_Ethan.Services
{
    public class CavesService : ICavesService
    {
        private readonly ICavesRepository _cavesRepository;
        public CavesService(ICavesRepository cavesRepository)
        {
            _cavesRepository = cavesRepository;
        }

        public async Task<Cave> UpdateAsync(int id, UpdateCaveDto caveToUpdate)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");

            if (caveToUpdate == null)
                throw new ArgumentNullException(nameof(caveToUpdate));

            if (caveToUpdate.Location.Length > 32)
                throw new ArgumentOutOfRangeException(nameof(caveToUpdate.Location), caveToUpdate.Location, "Location length cannot be greater than 32.");

            if (!await _cavesRepository.ExistsById(id))
                throw new DataNotFoundException($"Cave Id:{id} doesn't exists.");

            return await _cavesRepository.UpdateAsync(id, caveToUpdate);
        }

        public async Task<Cave> CreateAsync(CreateCaveDto caveToCreate)
        {
            if (caveToCreate == null)
                throw new ArgumentNullException(nameof(caveToCreate));

            if (caveToCreate.Location.Length > 32)
                throw new ArgumentOutOfRangeException(nameof(caveToCreate.Location), caveToCreate.Location, "Location name length cannot be greater than 32.");

            if (await _cavesRepository.ExistsByLocationAndDegree(caveToCreate.Location, caveToCreate.Degree))
                throw new ArgumentException(nameof(caveToCreate.Location), $"Cave {caveToCreate.Location} - {caveToCreate.Degree} already exists.");

            var modelDb = await _cavesRepository.CreateAsync(caveToCreate);

            return modelDb;
        }

        public Task<List<CaveSummaryViewModel>> GetAll(string filterByLocation)
        {
            if (filterByLocation?.Length < 4) {
                throw new ArgumentOutOfRangeException("Location length must be greater than 3.");
            }
            return _cavesRepository.Search(filterByLocation);
        }

        public async Task<bool> Delete(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");

            var result = await _cavesRepository.Delete(id);

            //If result == 1, one entity has been deleted from the database
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}