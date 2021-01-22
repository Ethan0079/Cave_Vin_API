using System.Collections.Generic;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Models;

namespace Epsic_Cave_A_Vin_Ethan.Repositories
{
    public interface IUsersRepository
    {
        Task<User> CreateAsync(CreateUserDto userToCreate);
        Task<int> Delete(int id);
        Task<bool> ExistsById(int id);
        Task<bool> ExistsByName(string username);
        Task<UserDetailViewModel> GetSingle(int id);
        Task<List<UserSummaryViewModel>> Search(string username);
        Task<User> UpdateAsync(int id, UpdateUserDto userToUpdate);
    }
}