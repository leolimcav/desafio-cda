using desafio_cda.api.DTO;
using desafio_cda.api.Models;
using desafio_cda.api.Repositories.Interfaces;
using desafio_cda.api.Services.Interfaces;
using desafio_cda.api.ViewModels;

namespace desafio_cda.api.Services.Implementations;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;

  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<User?> GetByUserName(string userName)
  {
    var user = await _userRepository.GetByUsername(userName);

    return user ?? null;
  }

  public async Task<UserViewModel> CreateAsync(CreateUserDTO dto)
  {
    var userNameExists = await _userRepository.GetByUsername(dto.UserName);

    if (userNameExists is not null)
    {
      return null;
    }
    var createdUser = await _userRepository.SaveAsync(dto);
    
    return UserViewModel.ModelToViewModel(createdUser);
  }
}
