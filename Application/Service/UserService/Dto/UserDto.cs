using System;

namespace JWT_NET_5.Application.Service.UserService.Dto
{
	public class UserDto:UserCreateDto
	{
		public Guid Id { get; set; }
	}
}
