using JWT_NET_5.AuthModels;
using JWT_NET_5.Data.AuthModels;
using JWT_NET_5.EntityFrameork.Identity;
using JWT_NET_5.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWT_NET_5.Service
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly JWT _jwt;

		public AuthService(UserManager<ApplicationUser> userManager,IOptions<JWT> jwt,RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_jwt = jwt.Value;
		}

		public async Task<string> AddRoleToUserAsync(UserRoleModel userRoleModel)
		{
			var user = await _userManager.FindByIdAsync(userRoleModel.UserId);
			if (user == null || !await _roleManager.RoleExistsAsync(userRoleModel.Role))
				return "Invalid User ID Or Role Name";
			if (await _userManager.IsInRoleAsync(user, userRoleModel.Role))
				return $"This User ID {user.Id} Already Assigned To This Role {userRoleModel.Role}";

			var result = await _userManager.AddToRoleAsync(user, userRoleModel.Role);
			return result.Succeeded ? String.Empty : "Error During Assigning Role To User";
		}

		public async Task<AuthModel> LoginAsync(LoginModel loginModel)
		{
			var authModel = new AuthModel();
			var user = await _userManager.FindByEmailAsync(loginModel.Email);
			if (user == null || !await _userManager.CheckPasswordAsync(user, loginModel.Password))
			{
				authModel.Message = "Invalid Email Or Password!! ";
				return authModel;
			}
			var jwtSecurityToken = await CreateJwtToken(user);
			var roles = await _userManager.GetRolesAsync(user);
			authModel.UserName = user.UserName;
			authModel.Email = user.Email;
			authModel.IsAuthenticated = true;
			authModel.Roles = roles.ToList();
			authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
			authModel.ExpireOn = jwtSecurityToken.ValidTo;
			
			return authModel;
		}

		public async Task<AuthModel> RegisterAsync(UserRegisterModel registerModel)
		{
			if (await _userManager.FindByEmailAsync(registerModel.Email) is not null)
				return new AuthModel() {Message="This Email Adress Is Used Before, Try Another Email!! " };
			if(await _userManager.FindByNameAsync(registerModel.UserName) is not null)
				return new AuthModel() { Message="This Name Is Used Before,Try Another Name !!"};
			var user = new ApplicationUser()
			{
				FirstName = registerModel.FirstName,
				LastName = registerModel.LastName,
				Email = registerModel.Email,
				UserName = registerModel.UserName,
			};
			var result = await _userManager.CreateAsync(user,registerModel.Password);
			if (!result.Succeeded)
				return new AuthModel()
				{
					Message = string.Join
					(',', result.Errors.Select(e => e.Description).ToArray())
				};
			await _userManager.AddToRoleAsync(user, "User");
			var jwtSecurityToken =await CreateJwtToken(user);
			return new AuthModel()
			{
				UserName = user.UserName,
				Email = user.Email,
				IsAuthenticated = true,
				Roles = new List<string>{"User" },
				Token=new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
				ExpireOn=jwtSecurityToken.ValidTo
			};
		}

		private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
		{
			var userClaims = await _userManager.GetClaimsAsync(user);
			var roles = await _userManager.GetRolesAsync(user);
			var roleClaims = new List<Claim>();

			foreach (var role in roles)
				roleClaims.Add(new Claim("roles", role));

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("uid", user.Id)
			}
			.Union(userClaims)
			.Union(roleClaims);

			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

			var jwtSecurityToken = new JwtSecurityToken(
				issuer: _jwt.Issuer,
				audience: _jwt.Audiance,
				claims: claims,
				expires: DateTime.Now.AddHours(_jwt.TimeOutInHours),
				signingCredentials: signingCredentials);

			return jwtSecurityToken;
		}
	}
}
