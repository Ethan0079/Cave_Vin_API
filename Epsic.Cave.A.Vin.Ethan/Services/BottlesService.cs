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

        public Task<List<BottleSummaryViewModel>> GetAll(string filterByName)
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

        //public async Task<bool> AddCharacterToBottle(AddCharacterToBottleDto addCharacterToBottle)
        //{
        //    if (addCharacterToBottle == null)
        //        throw new ArgumentNullException(nameof(addCharacterToBottle));

        //    if (addCharacterToBottle.BottleId < 1)
        //        throw new ArgumentOutOfRangeException(nameof(addCharacterToBottle.BottleId), addCharacterToBottle.BottleId, "Bottle Id cannot be lower than 1.");

        //    if (addCharacterToBottle.CharacterId < 1)
        //        throw new ArgumentOutOfRangeException(nameof(addCharacterToBottle.CharacterId), addCharacterToBottle.CharacterId, "Character Id cannot be lower than 1.");

        //    if (!await _bottlesRepository.ExistsById(addCharacterToBottle.BottleId))
        //        throw new DataNotFoundException($"Bottle Id:{addCharacterToBottle.BottleId} doesn't exists.");

        //    // Ici, si on avait un CharacterRepository on devrait checker si le CharacterId existe dans la db
        //    // if (!_characterRepository.ExistsById(addCharacterToBottle.CharacterId))
        //    //     throw new DataNotFoundException($"CharacterId:{addCharacterToBottle.CharacterId} doesn't exists.");

        //    var result = await _bottlesRepository.AddCharacterToBottle(addCharacterToBottle.BottleId, addCharacterToBottle.CharacterId);

        //    if (result == 1)
        //        return true;
        //    else
        //        return false;
        //}

        //public async Task<bool> RemoveCharacterFromBottle(RemoveCharacterFromBottleDto removeCharacterFromBottle)
        //{
        //    if (removeCharacterFromBottle == null)
        //        throw new ArgumentNullException(nameof(removeCharacterFromBottle));

        //    if (removeCharacterFromBottle.BottleId < 1)
        //        throw new ArgumentOutOfRangeException(nameof(removeCharacterFromBottle.BottleId), removeCharacterFromBottle.BottleId, "Bottle Id cannot be lower than 1.");

        //    if (removeCharacterFromBottle.CharacterId < 1)
        //        throw new ArgumentOutOfRangeException(nameof(removeCharacterFromBottle.CharacterId), removeCharacterFromBottle.CharacterId, "Character Id cannot be lower than 1.");

        //    if (!await _bottlesRepository.ExistsById(removeCharacterFromBottle.BottleId))
        //        throw new DataNotFoundException($"Bottle Id:{removeCharacterFromBottle.BottleId} doesn't exists.");

        //    // Ici, si on avait un CharacterRepository on devrait checker si le CharacterId existe dans la db
        //    // if (!_characterRepository.ExistsById(addCharacterToBottle.CharacterId))
        //    //     throw new DataNotFoundException($"CharacterId:{addCharacterToBottle.CharacterId} doesn't exists.");

        //    var result = await _bottlesRepository.RemoveCharacterFromBottle(removeCharacterFromBottle.BottleId, removeCharacterFromBottle.CharacterId);

        //    if (result == 1)
        //        return true;
        //    else
        //        return false;
        //}
    }
}