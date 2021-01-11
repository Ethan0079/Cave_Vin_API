using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epsic.Cave.A.Vin.Ethan.Data;
using Epsic.Cave.A.Vin.Ethan.Models;
using Microsoft.EntityFrameworkCore;

namespace Epsic.Cave.A.Vin.Ethan.Repositories
{

    public class BottlesRepository : IBottlesRepository
    {
        private readonly EpsicCaveAVinDataContext _context;
        public BottlesRepository(EpsicCaveAVinDataContext context)
        {
            _context = context;
        }

        public Task<BottleDetailViewModel> GetSingle(int id)
        {
            return _context.Bottles.Select(t => new BottleDetailViewModel
                                 {
                                     Id = t.Id,
                                     Name = t.Name,
                                     Date = t.Date,
                                     Typevin = t.Typevin,
                                     Owner = t.Owner,
                                     Cave = t.Cave
                                 }).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Bottle> UpdateAsync(int id, UpdateBottleDto bottleToUpdate)
        {
            var bottle = await _context.Bottles.FirstAsync(c => c.Id == id);

            bottle.Name = bottleToUpdate.Name;
            bottle.Date = bottleToUpdate.Date;
            bottle.Typevin = bottleToUpdate.Typevin;
            bottle.Owner = bottleToUpdate.Owner;
            bottle.Cave = bottleToUpdate.Cave;

            await _context.SaveChangesAsync();

            return bottle;
        }

        public async Task<Bottle> CreateAsync(CreateBottleDto bottleToCreate)
        {
            var bottleDb = new Bottle();
            bottleDb.Name = bottleToCreate.Name;
            bottleDb.Date = bottleToCreate.Date;
            bottleDb.Typevin = bottleToCreate.Typevin;
            bottleDb.Owner = bottleToCreate.Owner;
            bottleDb.Cave = bottleToCreate.Cave;

            _context.Bottles.Add(bottleDb);
            await _context.SaveChangesAsync();

            return bottleDb;
        }

        public Task<List<BottleSummaryViewModel>> Search(string name)
        {
            return _context.Bottles.Where(c => string.IsNullOrWhiteSpace(name) || c.Name.Contains(name)).Select(t =>
            new BottleSummaryViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Date = t.Date
            }).ToListAsync();
        }
        
        public async Task<int> Delete(int id)
        {
            _context.Bottles.Remove(await _context.Bottles.FirstOrDefaultAsync(c => c.Id == id));
            return await _context.SaveChangesAsync();
        }

        //public async Task<int> AddCharacterToBottle(int bottleId, int characterId)
        //{
        //    var bottleDb = await _context.Bottles.Include(t => t.Characters).FirstOrDefaultAsync(c => c.Id == bottleId);

        //    bottleDb.Characters.Add(_context.Characters.Find(characterId));

        //    return await _context.SaveChangesAsync();
        //}

        //public async Task<int> RemoveCharacterFromBottle(int bottleId, int characterId)
        //{
        //    var bottleDb = await _context.Bottles.Include(t => t.Characters).FirstOrDefaultAsync(c => c.Id == bottleId);

        //    bottleDb.Characters.Remove(bottleDb.Characters.First(c => c.Id == characterId));

        //    return await _context.SaveChangesAsync();
        //}

        public Task<bool> ExistsById(int id)
        {
            return _context.Bottles.AnyAsync(c => c.Id == id);
        }

        public Task<bool> ExistsByName(string name)
        {
            return _context.Bottles.AnyAsync(c => c.Name == name);
        }
    }
}