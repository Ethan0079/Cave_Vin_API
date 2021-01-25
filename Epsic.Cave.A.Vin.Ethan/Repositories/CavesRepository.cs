using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Data;
using Epsic_Cave_A_Vin_Ethan.Models;
using Microsoft.EntityFrameworkCore;

namespace Epsic_Cave_A_Vin_Ethan.Repositories
{
    public class CavesRepository : ICavesRepository
    {
        private readonly EpsicCaveAVinDataContext _context;
        public CavesRepository(EpsicCaveAVinDataContext context)
        {
            _context = context;
        }

        public async Task<Cave> UpdateAsync(int id, UpdateCaveDto caveToUpdate)
        {
            var cave = await _context.Caves.FirstAsync(c => c.Id == id);
            // Console.WriteLine(cave);
            cave.Location = caveToUpdate.Location;
            cave.Degree = caveToUpdate.Degree;
            cave.ImageUrl = caveToUpdate.ImageUrl;

            await _context.SaveChangesAsync();

            return cave;
        }

        public async Task<Cave> CreateAsync(CreateCaveDto caveToCreate)
        {
            var caveDb = new Cave
            {
                Location = caveToCreate.Location,
                Degree = caveToCreate.Degree,
                ImageUrl = caveToCreate.ImageUrl
            };

            _context.Caves.Add(caveDb);
            await _context.SaveChangesAsync();

            return caveDb;
        }
        public Task<CaveSummaryViewModel> GetSingle(int id)
        {
            return _context.Caves.Select(t => new CaveSummaryViewModel
            {
                Id = t.Id,
                Location = t.Location,
                Degree = t.Degree,
                ImageUrl = t.ImageUrl
            }).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<CaveSummaryViewModel>> Search(string locationName)
        {
            return _context.Caves.Where(c => string.IsNullOrWhiteSpace(locationName) || c.Location.Contains(locationName)).Select(t =>
            new CaveSummaryViewModel
            {
                Id = t.Id,
                Location = t.Location,
                Degree = t.Degree,
                ImageUrl = t.ImageUrl
            }).ToListAsync();
        }
        
        public async Task<int> Delete(int id)
        {
            _context.Caves.Remove(await _context.Caves.FirstOrDefaultAsync(c => c.Id == id));
            return await _context.SaveChangesAsync();
        }

        public Task<bool> ExistsById(int id)
        {
            return _context.Caves.AnyAsync(c => c.Id == id);
        }

        public Task<bool> ExistsByName(string locationName)
        {
            return _context.Caves.AnyAsync(c => c.Location == locationName);
        }
        public Task<bool> ExistsByLocationAndDegree(string locationName, int degree)
        {
            return _context.Caves.AnyAsync(c => c.Location == locationName && c.Degree == degree);
        }
    }
}