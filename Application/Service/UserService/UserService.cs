using JWT_NET_5.Application.Service.UserService.Dto;
using JWT_NET_5.Core.Domain.UserDomain;
using System;
using System.Threading.Tasks;

namespace JWT_NET_5.Application.Service.UserService
{
	public class UserService : IUserService
	{
		public Task<User> CreateUser(UserCreateDto userCreateDto)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteUser(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<User> GetUserById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<User> GetUserByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<User> UpdateUser(UserUpdateDto userDto)
		{
			throw new NotImplementedException();
		}
	}
}
