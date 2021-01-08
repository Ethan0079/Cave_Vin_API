using Epsic.Cave.A.Vin.Ethan.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epsic.Cave.A.Vin.Ethan.Data
{
    public class EpsicCaveAVinDataContext : DbContext
    {
        // public DbSet<Character> Characters { get; set; }
        //public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        public EpsicCaveAVinDataContext(DbContextOptions<EpsicCaveAVinDataContext> options)
            : base(options)
        {

        }
    }
}
