using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Tournament.Data.Data;
using System.Reflection.Metadata.Ecma335;
    
namespace Tournament.Data.Repositories;

public class TournamentRepository : ITournamentRepository
{
    private readonly TournamentApiContext _context;
    public TournamentRepository(TournamentApiContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<TournamentDetails>> GetAllAsync()
    {
        var tournaments = await _context.TournamentDetails.ToListAsync();
        return tournaments;

    }
    public async Task<TournamentDetails> GetAsync(int id) => await _context.TournamentDetails
        .FindAsync(id);

    public async Task<bool> AnyAsync(int id)
    {
        var tournamentDetails = await _context.TournamentDetails.FindAsync(id);

        if (tournamentDetails == null)
        {
            return false;
        }
        return true;
    }
    public void Add(TournamentDetails tournamentDetails)
    {
        _context.TournamentDetails.Add(tournamentDetails);        
    }
    public void Update(TournamentDetails tournamentDetails)
    {
        _context.TournamentDetails.Update(tournamentDetails);
    }
    public void Remove(TournamentDetails tournamentDetails)
    {
        _context.TournamentDetails.Remove(tournamentDetails);    
    }
}
