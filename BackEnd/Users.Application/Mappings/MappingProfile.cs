using AutoMapper;
using Users.Domain.Models;
using Users.Application.DTOs;

namespace Users.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeo de User a UserDto
        CreateMap<User, UserDto>();

        // Mapeo de UserDto a User
        CreateMap<UserDto, User>();
    }
}
