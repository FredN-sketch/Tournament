using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tournament.Core.Dto;
using Tournament.Core.Entities;

namespace Tournament.Data.Data
{
    public class TournamentMappings : Profile
    {
        public TournamentMappings()
        {
            CreateMap<TournamentDetails, TournamentDto>().ReverseMap(); 
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<GameCreateDto, Game>().ReverseMap();
                //.ForMember(dest => dest.Id, opt => opt.Ignore())
                //.ForMember(dest => dest.TournamentDetails, opt => opt.Ignore()); // Ignore navigation property
        }

    }
}
