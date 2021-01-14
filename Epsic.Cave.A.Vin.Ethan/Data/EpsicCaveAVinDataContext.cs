using Epsic_Cave_A_Vin_Ethan.Models;
using Microsoft.EntityFrameworkCore;

namespace Epsic_Cave_A_Vin_Ethan.Data
{
    public class EpsicCaveAVinDataContext : DbContext
    {
        // public DbSet<Character> Characters { get; set; }
        //public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bottle> Bottles { get; set; }
        public DbSet<Epsic_Cave_A_Vin_Ethan.Models.Cave> Caves { get; set; }

        public EpsicCaveAVinDataContext(DbContextOptions<EpsicCaveAVinDataContext> options)
            : base(options)
        {

        }
    }
}
