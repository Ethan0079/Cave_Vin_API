using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Data;
using Epsic_Cave_A_Vin_Ethan.Models;
using Microsoft.EntityFrameworkCore;

namespace Epsic_Cave_A_Vin_Ethan.Repositories
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
                Cave = t.Cave,
                Amount = t.Amount,
                PricePerBottle = t.PricePerBottle,
                ImageUrl = t.ImageUrl

            }).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Bottle> UpdateAsync(int id, UpdateBottleDto bottleToUpdate)
        {
            var bottle = await _context.Bottles.FirstAsync(c => c.Id == id);

            bottle.Name = bottleToUpdate.Name;
            bottle.Date = bottleToUpdate.Date;
            bottle.Typevin = bottleToUpdate.Typevin;
            bottle.Amount = bottleToUpdate.Amount;
            bottle.PricePerBottle = bottleToUpdate.PricePerBottle;
            bottle.OwnerId = bottleToUpdate.OwnerId;
            bottle.CaveId = bottleToUpdate.CaveId;
            bottle.ImageUrl = bottleToUpdate.ImageUrl;

            await _context.SaveChangesAsync();

            return bottle;
        }

        public async Task<Bottle> CreateAsync(CreateBottleDto bottleToCreate)
        {
            var bottleDb = new Bottle
            {
                Name = bottleToCreate.Name,
                Date = bottleToCreate.Date,
                Typevin = bottleToCreate.Typevin,
                OwnerId = bottleToCreate.OwnerId,
                CaveId = bottleToCreate.CaveId,
                Amount = bottleToCreate.Amount,
                PricePerBottle = bottleToCreate.PricePerBottle,
                ImageUrl = bottleToCreate.ImageUrl ?? "/assets/img/image-not-found.png"
            };

            _context.Bottles.Add(bottleDb);
            await _context.SaveChangesAsync();

            return bottleDb;
        }

        public Task<List<BottleDetailViewModel>> Search(string name)
        {
            return _context.Bottles
                .Include(x => x.Owner)
                .Include(y => y.Cave)
                .Where(c => string.IsNullOrWhiteSpace(name) || c.Name.Contains(name)).Select(t =>
            new BottleDetailViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Date = t.Date,
                Amount = t.Amount,
                PricePerBottle = t.PricePerBottle,
                Typevin = t.Typevin,
                Cave = t.Cave,
                CaveId = t.CaveId,
                Owner = t.Owner,
                OwnerId = t.OwnerId,
                ImageUrl = t.ImageUrl
            }).ToListAsync();
        }
        
        public async Task<int> Delete(int id)
        {
            _context.Bottles.Remove(await _context.Bottles.FirstOrDefaultAsync(c => c.Id == id));
            return await _context.SaveChangesAsync();
        }

        public Task<bool> ExistsById(int id)
        {
            return _context.Bottles.AnyAsync(c => c.Id == id);
        }

        public Task<bool> ExistsByName(string name)
        {
            return _context.Bottles.AnyAsync(c => c.Name == name);
        }
        public Task<bool> ExistsByNameAndDate(string name, DateTime date)
        {
            return _context.Bottles.AnyAsync(c => c.Name == name && c.Date.Year == date.Year);
        }
    }
}