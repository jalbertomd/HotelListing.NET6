using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Core.Contracts;
using AutoMapper;
using HotelListing.API.Core.Models.Hotel;
using Microsoft.AspNetCore.Authorization;
using HotelListing.API.Core.Models;
using Microsoft.AspNetCore.OData.Query;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HotelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<HotelsController> _logger;
        private readonly IHotelsRepository _hotelsRepository;


        public HotelsController(IHotelsRepository hotelsRepository, IMapper mapper, ILogger<HotelsController> logger)
        {
            _hotelsRepository = hotelsRepository;
            _mapper = mapper;
            this._logger = logger;
        }

        // GET: api/Hotels
        [HttpGet("GetAll")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            //var hotels = await _hotelsRepository.GetAllAsync();
            //return Ok(_mapper.Map<List<HotelDto>>(hotels));
            var hotels = await _hotelsRepository.GetAllAsync<HotelDto>();
            return Ok(hotels);
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<PagedResult<HotelDto>>> GetPagedHotels([FromQuery] QueryParameters queryParameters)
        {
            var pagedHotelsResult = await _hotelsRepository.GetAllAsync<HotelDto>(queryParameters);
            return Ok(pagedHotelsResult);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {
            //var hotel = await _hotelsRepository.GetAsync(id);

            //if (hotel == null)
            //{
            //    return NotFound();
            //}

            //return Ok(_mapper.Map<HotelDto>(hotel));

            var hotel = await _hotelsRepository.GetAsync<HotelDto>(id);
            return Ok(hotel);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDto hotelDto)
        {
            //if (id != hotelDto.Id)
            //{
            //    return BadRequest();
            //}

            //var hotel = await _hotelsRepository.GetAsync(id);
            //if (hotel == null)
            //{
            //    return NotFound();
            //}

            //_mapper.Map(hotelDto, hotel);

            try
            {
                await _hotelsRepository.UpdateAsync(id, hotelDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelDto>> PostHotel(CreateHotelDto hotelDto)
        {
            //var hotel = _mapper.Map<Hotel>(hotelDto);
            //await _hotelsRepository.AddAsync(hotel);

            //return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);

            var hotel = await _hotelsRepository.AddAsync<CreateHotelDto, HotelDto>(hotelDto);
            return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            //var hotel = await _hotelsRepository.GetAsync(id);
            //if (hotel == null)
            //{
            //    return NotFound();
            //}

            await _hotelsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await _hotelsRepository.Exists(id);
        }
    }
}
