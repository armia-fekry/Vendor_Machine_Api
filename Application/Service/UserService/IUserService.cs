using JWT_NET_5.Application.Service.UserService.Dto;
using JWT_NET_5.Core.Domain.UserDomain;
using System;
using System.Threading.Tasks;

namespace JWT_NET_5.Application.Service.UserService
{
	public interface IUserService
    {
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByName(string name);
        Task<User> UpdateUser(UserUpdateDto userDto);
        Task<bool> DeleteUser(Guid id);
        Task<User> CreateUser(UserCreateDto userCreateDto);
    }
}
