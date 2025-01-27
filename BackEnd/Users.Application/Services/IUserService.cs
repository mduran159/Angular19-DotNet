using Users.Application.DTOs;
using Users.Domain.Models;

namespace Users.Application.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
    Task<User> CreateAsync(UserDto user);
    Task<User?> UpdateAsync(Guid id, UserDto userDto);
    Task<bool> DeleteAsync(Guid id);
}
