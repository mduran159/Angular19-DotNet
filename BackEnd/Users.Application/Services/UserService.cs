using Microsoft.EntityFrameworkCore;
using Users.Application.Data;
using Users.Application.DTOs;
using Users.Domain.Models;

namespace Users.Application.Services;

public class UserService : IUserService
{
    private readonly IAppDbContext _context;

    public UserService(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> CreateAsync(UserDto userDto)
    {
        var user = User.Create(
            firstName: userDto.FirstName,
            lastName: userDto.LastName,
            age: userDto.Age,
            gender: userDto.Gender,
            country: userDto.Country,
            address: userDto.Address,
            phone: userDto.Phone,
            email: userDto.Email
        );
        _context.Users.Add(user);
        await _context.SaveChangesAsync(CancellationToken.None);
        return user;
    }

    public async Task<User?> UpdateAsync(Guid id, UserDto userDto)
    {
        var existingUser = await _context.Users.FindAsync(id);

        if (existingUser == null)
            return null;

        existingUser.Update(
            userDto.FirstName,
            userDto.LastName,
            userDto.Age,
            userDto.Gender,
            userDto.Country,
            userDto.Address,
            userDto.Phone,
            userDto.Email
        );

        await _context.SaveChangesAsync(CancellationToken.None);
        return existingUser;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(CancellationToken.None);
        return true;
    }
}
