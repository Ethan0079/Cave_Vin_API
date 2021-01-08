using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epsic.Cave.A.Vin.Ethan.Exceptions;
using Epsic.Cave.A.Vin.Ethan.Models;
using Epsic.Cave.A.Vin.Ethan.Repositories;

namespace Epsic.Cave.A.Vin.Ethan.Services
{

    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<UserDetailViewModel> GetSingle(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");

            var userDb = await _usersRepository.GetSingle(id);

            return userDb;
        }

        public async Task<User> UpdateAsync(int id, UpdateUserDto userToUpdate)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");

            if (userToUpdate == null)
                throw new ArgumentNullException(nameof(userToUpdate));

            if (userToUpdate.Username.Length > 32)
                throw new ArgumentOutOfRangeException(nameof(userToUpdate.Username), userToUpdate.Username, "User name length cannot be greater than 32.");

            if (!await _usersRepository.ExistsById(id))
                throw new DataNotFoundException($"User Id:{id} doesn't exists.");

            if (await _usersRepository.ExistsByName(userToUpdate.Username))
                throw new ArgumentException(nameof(userToUpdate.Username), $"User {userToUpdate.Username} already exists.");

            return await _usersRepository.UpdateAsync(id, userToUpdate);
        }

        public async Task<User> CreateAsync(CreateUserDto userToCreate)
        {
            if (userToCreate == null)
                throw new ArgumentNullException(nameof(userToCreate));

            if (userToCreate.Username.Length > 32)
                throw new ArgumentOutOfRangeException(nameof(userToCreate.Username), userToCreate.Username, "User name length cannot be greater than 32.");

            if (await _usersRepository.ExistsByName(userToCreate.Username))
                throw new ArgumentException(nameof(userToCreate.Username), $"User {userToCreate.Username} already exists.");

            var modelDb = await _usersRepository.CreateAsync(userToCreate);

            return modelDb;
        }

        public Task<List<UserSummaryViewModel>> GetAll(string filterByName)
        {
            if (filterByName?.Length < 4)
                throw new ArgumentOutOfRangeException("User name length must be greater than 3.");

            return _usersRepository.Search(filterByName);
        }

        public async Task<bool> Delete(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id cannot be lower than 1.");

            var result = await _usersRepository.Delete(id);

            //If result == 1, one entity has been deleted from the database
            if (result == 1)
                return true;
            else
                return false;
        }

        public async Task<bool> AddCharacterToUser(AddCharacterToUserDto addCharacterToUser)
        {
            if (addCharacterToUser == null)
                throw new ArgumentNullException(nameof(addCharacterToUser));

            if (addCharacterToUser.UserId < 1)
                throw new ArgumentOutOfRangeException(nameof(addCharacterToUser.UserId), addCharacterToUser.UserId, "User Id cannot be lower than 1.");

            if (addCharacterToUser.CharacterId < 1)
                throw new ArgumentOutOfRangeException(nameof(addCharacterToUser.CharacterId), addCharacterToUser.CharacterId, "Character Id cannot be lower than 1.");

            if (!await _usersRepository.ExistsById(addCharacterToUser.UserId))
                throw new DataNotFoundException($"User Id:{addCharacterToUser.UserId} doesn't exists.");

            // Ici, si on avait un CharacterRepository on devrait checker si le CharacterId existe dans la db
            // if (!_characterRepository.ExistsById(addCharacterToUser.CharacterId))
            //     throw new DataNotFoundException($"CharacterId:{addCharacterToUser.CharacterId} doesn't exists.");

            var result = await _usersRepository.AddCharacterToUser(addCharacterToUser.UserId, addCharacterToUser.CharacterId);

            if (result == 1)
                return true;
            else
                return false;
        }

        public async Task<bool> RemoveCharacterFromUser(RemoveCharacterFromUserDto removeCharacterFromUser)
        {
            if (removeCharacterFromUser == null)
                throw new ArgumentNullException(nameof(removeCharacterFromUser));

            if (removeCharacterFromUser.UserId < 1)
                throw new ArgumentOutOfRangeException(nameof(removeCharacterFromUser.UserId), removeCharacterFromUser.UserId, "User Id cannot be lower than 1.");

            if (removeCharacterFromUser.CharacterId < 1)
                throw new ArgumentOutOfRangeException(nameof(removeCharacterFromUser.CharacterId), removeCharacterFromUser.CharacterId, "Character Id cannot be lower than 1.");

            if (!await _usersRepository.ExistsById(removeCharacterFromUser.UserId))
                throw new DataNotFoundException($"User Id:{removeCharacterFromUser.UserId} doesn't exists.");

            // Ici, si on avait un CharacterRepository on devrait checker si le CharacterId existe dans la db
            // if (!_characterRepository.ExistsById(addCharacterToUser.CharacterId))
            //     throw new DataNotFoundException($"CharacterId:{addCharacterToUser.CharacterId} doesn't exists.");

            var result = await _usersRepository.RemoveCharacterFromUser(removeCharacterFromUser.UserId, removeCharacterFromUser.CharacterId);

            if (result == 1)
                return true;
            else
                return false;
        }
    }
}