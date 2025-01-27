using System.Collections.Generic;
using System.Threading.Tasks;

namespace Users.Application.Services;

public class GenderService : IGenderService
{
    private readonly List<string> _countries = new()
    {
        "USA",
        "Canada",
        "Mexico",
        "Germany",
        "Japan"
    };

    public Task<IEnumerable<string>> GetGendersAsync()
    {
        var genders = new List<string> { "Male", "Female", "Other" };
        return Task.FromResult<IEnumerable<string>>(genders);
    }
}
