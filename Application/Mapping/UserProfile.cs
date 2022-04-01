using AutoMapper;
using JWT_NET_5.Application.Service.UserService.Dto;
using JWT_NET_5.Core.Domain.UserDomain;

namespace JWT_NET_5.Application.Mapping
{
	public class UserProfile:Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserDto>();
		}
	}
}
