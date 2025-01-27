using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Users.Application.DTOs;
using Users.Application.Services;
using Users.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IGenderService _genderService;
    private readonly ICountryService _countryService;
    private readonly IMapper _mapper;
    
    public UsersController(IUserService userService, IMapper mapper, IGenderService genderService, ICountryService countryService)
    {
        _userService = userService;
        _genderService = genderService;
        _countryService = countryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<User>> GetById(Guid id)
    {
        var user = await _userService.GetByIdAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] UserDto userDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdUser = await _userService.CreateAsync(userDto);

        return Ok(createdUser);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Edit(Guid id, [FromBody] UserDto userDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var updatedUser = await _userService.UpdateAsync(id, userDto);

        if (updatedUser == null)
            return NotFound();

        return Ok(updatedUser);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _userService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }

    [HttpGet("Genders")]
    public async Task<IActionResult> GetGenders()
    {
        var genders = await _genderService.GetGendersAsync();
        return Ok(genders);
    }

    [HttpGet("Countries")]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await _countryService.GetAllCountriesAsync();
        return Ok(countries);
    }
}