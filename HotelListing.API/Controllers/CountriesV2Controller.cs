using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Core.Models.Country;
using AutoMapper;
using HotelListing.API.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using HotelListing.API.Core.Exceptions;
using HotelListing.API.Core.Models;
using Microsoft.AspNetCore.OData.Query;

namespace HotelListing.API.Controllers
{
    [Route("api/v{version:apiVersion}/countries")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CountriesV2Controller : ControllerBase
    {
        //private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CountriesV2Controller> _logger;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesV2Controller(/*HotelListingDbContext context*/ICountriesRepository countriesRepository, IMapper mapper, ILogger<CountriesV2Controller> logger)
        {
            //_context = context;
            _countriesRepository = countriesRepository;
            _mapper = mapper;
            this._logger = logger;
        }

        // GET: api/Countries/GetAll
        [HttpGet("GetAll")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            //var countries = await _context.Countries.ToListAsync();
            var countries = await _countriesRepository.GetAllAsync();
            var countriesDto = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(countriesDto);
        }

        // GET: api/Countries?StartIndex=0&PageSize=2&PageNumber=1
        [HttpGet]
        public async Task<ActionResult<PagedResult<GetCountryDto>>> GetPagedCountries([FromQuery] QueryParameters queryParameters)
        {
            var pagedCountriesResult = await _countriesRepository.GetAllAsync<GetCountryDto>(queryParameters);
            return Ok(pagedCountriesResult);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            //var country = await _context.Countries.Include(h => h.Hotels)
            //    .FirstOrDefaultAsync(c => c.Id == id);

            var location = GetControllerActionNames();

            //try
            //{
            var country = await _countriesRepository.GetDetails(id);

            if (country is null)
            {
                throw new NotFoundException(location, id);
            }

            var countryDto = _mapper.Map<CountryDto>(country);

            return Ok(countryDto);
            //}
            //catch (Exception ex)
            //{
            //    return InternalError($"{location}: Error", ex);
            //}            
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            //var country = await _context.Countries.FindAsync(id);
            var country = await _countriesRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCountryDto, country);

            try
            {
                //await _context.SaveChangesAsync();
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountryDto)
        {
            var country = _mapper.Map<Country>(createCountryDto);

            //_context.Countries.Add(country);
            //await _context.SaveChangesAsync();

            await _countriesRepository.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            //var country = await _context.Countries.FindAsync(id);
            var country = await _countriesRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            //_context.Countries.Remove(country);
            //await _context.SaveChangesAsync();

            await _countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            //return _context.Countries.Any(e => e.Id == id);
            return await _countriesRepository.Exists(id);
        }

        private ObjectResult InternalError(string message, Exception ex = null)
        {
            if (ex != null)
            {
                _logger.LogError(ex, message);
                return Problem(ex.Message, statusCode: 500);
            }
            else
            {
                _logger.LogError(message);
                return Problem(message, statusCode: 500);
            }
        }

        private string GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }
    }
}
