using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Data.Entities;

namespace Tournament.Data.Data;

public static class SeedData
{
    public static List<TournamentDetails> GenerateTournaments()
    {
        var tournaments = new List<TournamentDetails>
            {

                new TournamentDetails
                {
                   
                    Title = "Spring Championship",                           
                    StartDate = DateTime.UtcNow.AddDays(30),
                    Games = GenerateGames("Spring Championship")
                },
                new TournamentDetails
                {
                    Title = "Summer Showdown",                           
                    StartDate = DateTime.UtcNow.AddDays(60), 
                    Games = GenerateGames("Summer Showdown")
                }
            };
        return tournaments;
    }
    public static List<Game> GenerateGames(string tournamentTitle)
    {
        var games = new List<Game>()
        {
            new Game
            {
                Title = tournamentTitle + " Game 1",
                Time = DateTime.UtcNow
            },
             new Game
            {
                Title = tournamentTitle + " Game 2",
                Time = DateTime.UtcNow
            }
        };
        return games;
    }

}
