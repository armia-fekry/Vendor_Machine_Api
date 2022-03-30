using JWT_NET_5.AuthModels;
using JWT_NET_5.Data.AuthModels;
using System.Threading.Tasks;

namespace JWT_NET_5.Service
{
	public interface IAuthService
	{
		Task<AuthModel> RegisterAsync(UserRegisterModel registerModel);
		Task<AuthModel> LoginAsync(LoginModel loginModel);
		Task<string> AddRoleToUserAsync(UserRoleModel userRoleModel);
	}
}
