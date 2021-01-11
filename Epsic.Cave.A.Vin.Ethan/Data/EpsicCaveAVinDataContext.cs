using Epsic.Cave.A.Vin.Ethan.Models;
using Microsoft.EntityFrameworkCore;

namespace Epsic.Cave.A.Vin.Ethan.Data
{
    public class EpsicCaveAVinDataContext : DbContext
    {
        // public DbSet<Character> Characters { get; set; }
        //public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bottle> Bottles { get; set; }
        public DbSet<Epsic.Cave.A.Vin.Ethan.Models.Cave> Caves { get; set; }

        public EpsicCaveAVinDataContext(DbContextOptions<EpsicCaveAVinDataContext> options)
            : base(options)
        {

        }
    }
}
