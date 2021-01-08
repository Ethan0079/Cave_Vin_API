using System.Collections.Generic;
using System.Threading.Tasks;
using Epsic.Cave.A.Vin.Ethan.Models;

namespace Epsic.Cave.A.Vin.Ethan.Repositories
{
    public interface IUsersRepository
    {
        // Task<int> AddCharacterToUser(int userId, int characterId);
        Task<User> CreateAsync(CreateUserDto userToCreate);
        Task<int> Delete(int id);
        Task<bool> ExistsById(int id);
        Task<bool> ExistsByName(string username);
        Task<UserDetailViewModel> GetSingle(int id);

        // Task<int> RemoveCharacterFromUser(int userId, int characterId);
        // Task<List<UserSummaryViewModel>> Search(string username);
        Task<User> UpdateAsync(int id, UpdateUserDto userToUpdate);
    }
}