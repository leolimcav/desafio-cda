using desafio_cda.api.DTO;
using desafio_cda.api.Services.Interfaces;
using desafio_cda.api.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace desafio_cda.api.Controllers;

[Route("/users")]
public class UserController : BaseController
{
  private readonly IUserService _userService;

  public UserController(IUserService userService)
  {
    _userService = userService;
  }
  
  [HttpPost]
  public async Task<ActionResult<UserViewModel>> Create([FromBody]CreateUserDTO dto)
  {
    var createdUser = await _userService.CreateAsync(dto);

    if (createdUser is null)
    {
      return BadRequest("Error with the fields!");
    }

    return Created("", createdUser);
  }
}
