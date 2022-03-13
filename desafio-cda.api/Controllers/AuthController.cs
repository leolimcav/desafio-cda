using desafio_cda.api.DTO;
using desafio_cda.api.Services.Interfaces;
using desafio_cda.api.Utils;
using desafio_cda.api.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace desafio_cda.api.Controllers;

[Route("/auth")]
public class AuthController : BaseController
{
  private readonly IUserService _userService;

  public AuthController(IUserService userService)
  {
    _userService = userService;
  }
  
  [HttpPost("/register")]
  public async Task<ActionResult<UserViewModel>> Register([FromBody]CreateUserDTO dto)
  {
    var createdUser = await _userService.CreateAsync(dto);

    if (createdUser is null)
    {
      return BadRequest("Username already exists!");
    }

    return Created("", createdUser);
  }

  [HttpPost("/login")]
  public async Task<ActionResult<UserViewModel>> Login([FromBody] AuthDTO dto)
  {
    var user = await _userService.GetByUserName(dto.UserName);

    if (user is null)
    {
      return NotFound("User not found");
    }

    if (!PasswordHelper.CheckPassword(dto.Password, user.Password))
    {
      return BadRequest("Username/Password is wrong!");
    }

    return Ok(UserViewModel.ModelToViewModel(user));
  }
}
