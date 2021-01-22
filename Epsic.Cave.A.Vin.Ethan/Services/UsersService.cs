using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Exceptions;
using Epsic_Cave_A_Vin_Ethan.Models;
using Epsic_Cave_A_Vin_Ethan.Repositories;

namespace Epsic_Cave_A_Vin_Ethan.Services
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

            if (userToUpdate.Firstname.Length > 32)
                throw new ArgumentOutOfRangeException(nameof(userToUpdate.Firstname), userToUpdate.Firstname, "Firstname length cannot be greater than 32.");

            if (!await _usersRepository.ExistsById(id))
                throw new DataNotFoundException($"User Id:{id} doesn't exists.");

            return await _usersRepository.UpdateAsync(id, userToUpdate);
        }

        public async Task<User> CreateAsync(CreateUserDto userToCreate)
        {
            if (userToCreate == null)
                throw new ArgumentNullException(nameof(userToCreate));

            if (userToCreate.Firstname.Length > 32)
                throw new ArgumentOutOfRangeException(nameof(userToCreate.Firstname), userToCreate.Firstname, "User name length cannot be greater than 32.");

            if (await _usersRepository.ExistsByName(userToCreate.Firstname))
                throw new ArgumentException(nameof(userToCreate.Firstname), $"User {userToCreate.Firstname} already exists.");

            var modelDb = await _usersRepository.CreateAsync(userToCreate);

            return modelDb;
        }

        public Task<List<UserSummaryViewModel>> GetAll(string filterByName)
        {
            if (filterByName?.Length < 4){
                throw new ArgumentOutOfRangeException("Firstname length must be greater than 3.");
            }
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

    }
}