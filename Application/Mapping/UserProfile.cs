using AutoMapper;
using JWT_NET_5.Application.Service.UserService.Dto;
using JWT_NET_5.Core.Domain.UserDomain;

namespace JWT_NET_5.Application.Mapping
{
	public class UserProfile:Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserDto>()
				.ForMember(dto => dto.Id, model => model.MapFrom(e => e.Id))
				.ForMember(dto => dto.UserName, model => model.MapFrom(e => e.UserName))
				.ForMember(dto => dto.Deposit, model => model.MapFrom(e => e.Deposit))
				.ForMember(dto => dto.Role, model => model.MapFrom(e => e.Role));
			CreateMap<UserDto,User>();
			CreateMap<UserUpdateDto, User>();
		}
	}
}
