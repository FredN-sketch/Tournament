using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<TournamentDetails>> GetAllTournamentsAsync();
        Task<TournamentDetails> GetTournamentByIdAsync(Guid tournamentId);
        Task AddTournamentAsync(TournamentDetails tournament);
        Task UpdateTournamentAsync(TournamentDetails tournament);
        Task DeleteTournamentAsync(Guid tournamentId);
    }
}
