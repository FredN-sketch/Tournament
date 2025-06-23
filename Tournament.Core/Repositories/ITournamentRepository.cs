using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
us
namespace Tournament.Core.Repositories
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<TournamentDetails>> GetAllTournamentsAsync();
        Task<Tournament> GetTournamentByIdAsync(Guid tournamentId);
        Task AddTournamentAsync(Tournament tournament);
        Task UpdateTournamentAsync(Tournament tournament);
        Task DeleteTournamentAsync(Guid tournamentId);
    }
}
