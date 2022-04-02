using JWT_NET_5.Application.Service.UserService;
using JWT_NET_5.Application.Service.UserService.Dto;
using JWT_NET_5.Common.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT_NET_5.Controllers
{
	[Route("api")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IHttpContextAccessor _httpContext;

		public UserController(IUserService userService, IHttpContextAccessor httpContext)
		{
			_userService = userService;
			_httpContext = httpContext;
		}
		
		// GET: api/Users
		[Authorize]
		[HttpGet("Users")]
		public async Task<List<UserDto>> Get()
		{
			return await _userService.GetAllUsers();
		}

		// GET api/users/5
		[Authorize]
		[HttpGet("Users/{id}")]
		public async Task<UserDto> Get(Guid id)
		{
			return await _userService.GetUserById(id); 
		}

		// POST api/users
		[HttpPost("User")]
		public async Task<UserDto> Post([FromBody] UserCreateDto userCreateDto)
		{
			return await _userService.CreateUser(userCreateDto);
		}

		// PUT api/users/5
		[Authorize]
		[HttpPut("User/{id}")]
		public async Task<ActionResult<UserDto>> Put(Guid id, [FromBody] UserUpdateDto updateDto)
		{
			if (ModelState.IsValid)
				return BadRequest("Comlete requierd Fields ");
			AssertionConcern.AssertionAgainstNotNull(id, "Invalid User Id");
			updateDto.Id = id;
			return Ok(await _userService.UpdateUser(updateDto));
		}

		// DELETE api/users/5
		[Authorize]
		[HttpDelete("User/{id}")]
		public async Task<ActionResult<bool>> Delete(Guid id)
		{
			if(id == default(Guid)) return BadRequest("Invalid ID ");
			return Ok(await _userService.DeleteUser(id));
		}
		[Authorize(Roles ="Buyer")]
		[HttpPost("User/deposit")]
		public async Task<ActionResult<UserDto>> Deposit(Guid userId, int coins)
		{
			if (userId == default(Guid)) return BadRequest("Invalid ID ");
			return Ok(await _userService.Deposit(userId,coins));
		}
		[Authorize(Roles = "Buyer")]
		[HttpPost("User/resetdeposit")]
		public async Task<ActionResult<UserDto>> ResetDeposit(Guid userId)
		{
			if (userId == default(Guid)) return BadRequest("Invalid ID ");
			return Ok(await _userService.Deposit(userId, 0));
		}
		[Authorize(Roles = "Buyer")]
		[HttpPost("User/Buy")]
		public async Task<ActionResult<string>> Buy(Guid productId,int amountOfProduct)
		{
			var UserId = _httpContext.HttpContext?.User.Claims.
				FirstOrDefault(e => e.Type == "uid")?.Value;
			AssertionConcern.AssertionAgainstNotNull(UserId, "Invalid User Id");
			if (amountOfProduct < 1)
				return BadRequest("please enter amount of product you need");
			var res = await _userService.Buy(Guid.Parse(UserId), productId, amountOfProduct);
			return Ok(res);
		}
	}
}
