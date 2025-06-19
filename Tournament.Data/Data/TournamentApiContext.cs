using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tournament.Data.Entities;

namespace Tournament.Data.Data
{
    public class TournamentApiContext : DbContext
    {
        public TournamentApiContext (DbContextOptions<TournamentApiContext> options)
            : base(options)
        {
        }

        public DbSet<Tournament.Data.Entities.TournamentDetails> TournamentDetails { get; set; } = default!;
        public DbSet<Tournament.Data.Entities.Game> Game { get; set; } = default!;
    }
}
