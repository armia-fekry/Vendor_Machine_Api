using JWT_NET_5.Infrastructure.Data;
using JWT_NET_5.EntityFrameork.Identity;
using JWT_NET_5.Helper;
using JWT_NET_5.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JWT_NET_5
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//bind JWt COnfiguration At AppSetting.Json To JWT Class And Register
			//It To .NET Container
			services.Configure<JWT>(Configuration.GetSection("JWT"));
			//Add Identity And Roles
			services.AddIdentity<ApplicationUser,IdentityRole>()
				.AddEntityFrameworkStores<JWTDbContext>();
			services.AddDbContext<JWTDbContext>(options =>
					options.UseSqlServer(Configuration.GetConnectionString("Default")));
			//Register Auth Service
			services.AddScoped<IAuthService,AuthService>();

			#region JWT Authentication Setting
			services.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				   .AddJwtBearer(o =>
				   {
					   o.RequireHttpsMetadata = false;
					   o.SaveToken = false;
					   o.TokenValidationParameters = new TokenValidationParameters
					   {
						   ValidateIssuerSigningKey = true,
						   ValidateIssuer = true,
						   ValidateAudience = true,
						   ValidateLifetime = true,
						   ValidIssuer = Configuration["JWT:Issuer"],
						   ValidAudience = Configuration["JWT:Audience"],
						   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
					   };
				   }); 
			#endregion


			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
