using JWT_NET_5.Application.Service.UserService.Dto;
using JWT_NET_5.Core.Domain.UserDomain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWT_NET_5.Application.Service.UserService
{
	public interface IUserService
    {
        Task<UserDto> GetUserById(Guid id);
        Task<UserDto> GetUserByName(string name);
        Task<UserDto> UpdateUser(UserUpdateDto userDto);
        Task<bool> DeleteUser(Guid id);
        Task<UserDto> CreateUser(UserCreateDto userCreateDto);
        Task<List<UserDto>> GetAllUsers();
		Task<UserDto> Deposit(Guid userId,int coins);
	}
}
