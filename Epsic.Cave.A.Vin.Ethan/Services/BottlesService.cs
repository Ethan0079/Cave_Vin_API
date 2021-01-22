using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Exceptions;
using Epsic_Cave_A_Vin_Ethan.Models;
using Epsic_Cave_A_Vin_Ethan.Repositories;

namespace Epsic_Cave_A_Vin_Ethan.Services
{

    public class BottlesService : IBottlesService
    {
        private readonly IBottlesRepository _bottlesRepository;
        public BottlesService(IBottlesRepository bottlesRepository)
        {
            _bottlesRepository = bottlesRepository;
        }

        public async Task<BottleDetailViewModel> GetSingle(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");

            var bottleDb = await _bottlesRepository.GetSingle(id);

            return bottleDb;
        }

        public async Task<Bottle> UpdateAsync(int id, UpdateBottleDto bottleToUpdate)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");

            if (bottleToUpdate == null)
                throw new ArgumentNullException(nameof(bottleToUpdate));

            if (bottleToUpdate.Name.Length > 32)
                throw new ArgumentOutOfRangeException(nameof(bottleToUpdate.Name), bottleToUpdate.Name, "Name length cannot be greater than 32.");

            if (!await _bottlesRepository.ExistsById(id))
                throw new DataNotFoundException($"Bottle Id:{id} doesn't exists.");

            if (await _bottlesRepository.ExistsByName(bottleToUpdate.Name))
                throw new ArgumentException(nameof(bottleToUpdate.Name), $"Bottle {bottleToUpdate.Name} already exists.");

            return await _bottlesRepository.UpdateAsync(id, bottleToUpdate);
        }

        public async Task<Bottle> CreateAsync(CreateBottleDto bottleToCreate)
        {
            if (bottleToCreate == null)
                throw new ArgumentNullException(nameof(bottleToCreate));

            if (bottleToCreate.Name.Length > 32)
                throw new ArgumentOutOfRangeException(nameof(bottleToCreate.Name), bottleToCreate.Name, "Bottle name length cannot be greater than 32.");

            if (await _bottlesRepository.ExistsByName(bottleToCreate.Name))
                throw new ArgumentException(nameof(bottleToCreate.Name), $"Bottle {bottleToCreate.Name} already exists.");

            var modelDb = await _bottlesRepository.CreateAsync(bottleToCreate);

            return modelDb;
        }

        public Task<List<BottleDetailViewModel>> GetAll(string filterByName)
        {
            if (filterByName?.Length < 4) {
                throw new ArgumentOutOfRangeException("Name length must be greater than 3.");
            }
            return _bottlesRepository.Search(filterByName);
        }

        public async Task<bool> Delete(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");

            var result = await _bottlesRepository.Delete(id);

            //If result == 1, one entity has been deleted from the database
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}