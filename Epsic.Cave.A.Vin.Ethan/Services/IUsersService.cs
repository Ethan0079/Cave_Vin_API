using System.Collections.Generic;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Models;

namespace Epsic_Cave_A_Vin_Ethan.Services
{
    public interface IUsersService
    {
        Task<User> CreateAsync(CreateUserDto userToCreate);
        Task<bool> Delete(int id);
        Task<List<UserSummaryViewModel>> GetAll(string filterByName);
        Task<UserDetailViewModel> GetSingle(int id);
        Task<User> UpdateAsync(int id, UpdateUserDto userToUpdate);
    }
}