using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Data.Data;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using AutoMapper;
using Tournament.Core.Dto;

namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentDetailsController : ControllerBase
    {
        //private readonly TournamentApiContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public TournamentDetailsController(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        // GET: api/TournamentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetTournamentDetails()
        {
            //return await _context.TournamentDetails.ToListAsync();
            //var tournaments = await _uow.TournamentRepository.GetAllAsync();
            var tournaments = _mapper.Map<IEnumerable<TournamentDto>>(await _uow.TournamentRepository.GetAllAsync());
            return Ok(tournaments);
        }

        // GET: api/TournamentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentDto>> GetTournamentDetails(int id)
        {
            //var tournamentDetails = await _uow.TournamentRepository.GetAsync(id);
            var tournamentDetails = _mapper.Map<TournamentDto>(await _uow.TournamentRepository.GetAsync(id));

            if (tournamentDetails == null)
            {
                return NotFound();
            }

            return Ok(tournamentDetails);
        }

        // PUT: api/TournamentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournamentDetails(int id, TournamentDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            // _uow.TournamentRepository.Update(dto);
            var existingTournament = await _uow.TournamentRepository.GetAsync(id);
            if (existingTournament == null)
            {
                return NotFound("Tournament does not exist");
            }

            _mapper.Map(dto, existingTournament);


            try
            {
                await _uow.CompleteAsync();
            }
            catch
            {
                return StatusCode(500);
            }  
            
            return NoContent();
        }

        // POST: api/TournamentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TournamentDto>> PostTournamentDetails(TournamentDto dto)
        {
            var tournamentDetails = _mapper.Map<TournamentDetails>(dto);

            _uow.TournamentRepository.Add(tournamentDetails);
            try
            {
                await _uow.CompleteAsync();
            }
            catch
            {
                return StatusCode(500);
            }
            var createdTournament = _mapper.Map<TournamentDto>(tournamentDetails);
            return CreatedAtAction(nameof(GetTournamentDetails), new { id = tournamentDetails.Id }, createdTournament);
        }

        // DELETE: api/TournamentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournamentDetails(int id)
        {
            var tournamentDetails = await _uow.TournamentRepository.GetAsync(id);
            if (tournamentDetails == null)
            {
                return NotFound();
            }

            _uow.TournamentRepository.Remove(tournamentDetails);
            try
            {
                await _uow.CompleteAsync();
            }
            catch
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        private async Task<bool> TournamentDetailsExists(int id)
        {
            return await _uow.TournamentRepository.AnyAsync(id);
        }
    }
}
