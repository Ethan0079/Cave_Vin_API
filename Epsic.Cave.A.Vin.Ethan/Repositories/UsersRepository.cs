using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Data;
using Epsic_Cave_A_Vin_Ethan.Models;
using Microsoft.EntityFrameworkCore;

namespace Epsic_Cave_A_Vin_Ethan.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly EpsicCaveAVinDataContext _context;
        public UsersRepository(EpsicCaveAVinDataContext context)
        {
            _context = context;
        }

        public Task<UserDetailViewModel> GetSingle(int id)
        {
            return _context.Users.Select(t => new UserDetailViewModel
            {
                Id = t.Id,
                Firstname = t.Firstname,
                LastName = t.LastName,
                Email = t.Email,
                Age = t.Age,
                Type = t.Type
            }).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<User> UpdateAsync(int id, UpdateUserDto userToUpdate)
        {
            var user = await _context.Users.FirstAsync(c => c.Id == id);

            user.Firstname = userToUpdate.Firstname;
            user.LastName = userToUpdate.LastName;
            user.Email = userToUpdate.Email;
            user.Age = userToUpdate.Age;

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> CreateAsync(CreateUserDto userToCreate)
        {
            var userDb = new User
            {
                Firstname = userToCreate.Firstname,
                LastName = userToCreate.LastName,
                Email = userToCreate.Email,
                Age = userToCreate.Age
            };

            _context.Users.Add(userDb);
            await _context.SaveChangesAsync();

            return userDb;
        }

        public Task<List<UserSummaryViewModel>> Search(string name)
        {
            return _context.Users.Where(c => string.IsNullOrWhiteSpace(name) || c.Firstname.Contains(name)).Select(t =>
            new UserSummaryViewModel
            {
                Id = t.Id,
                Firstname = t.Firstname,
                Lastname = t.LastName
            }).ToListAsync();
        }
        
        public async Task<int> Delete(int id)
        {
            _context.Users.Remove(await _context.Users.FirstOrDefaultAsync(c => c.Id == id));
            return await _context.SaveChangesAsync();
        }

        public Task<bool> ExistsById(int id)
        {
            return _context.Users.AnyAsync(c => c.Id == id);
        }

        public Task<bool> ExistsByName(string name)
        {
            return _context.Users.AnyAsync(c => c.Firstname == name);
        }
    }
}