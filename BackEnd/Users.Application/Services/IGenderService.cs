namespace Users.Application.Services;
public interface IGenderService
{
    Task<IEnumerable<string>> GetGendersAsync();
}
