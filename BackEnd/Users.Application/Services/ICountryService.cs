namespace Users.Application.Services;
public interface ICountryService
{
    Task<IEnumerable<string>> GetAllCountriesAsync();
}
