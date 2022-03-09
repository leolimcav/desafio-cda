using desafio_cda.api.DTO;
using desafio_cda.api.Repositories.Interfaces;
using desafio_cda.api.Services.Interfaces;
using desafio_cda.api.ViewModels;

namespace desafio_cda.api.Services.Implementations;

public class UserService : IUserService
{
  private readonly ILogger _logger;
  private readonly IUserRepository _userRepository;

  public UserService(IUserRepository userRepository, ILogger<UserService> logger)
  {
    _userRepository = userRepository;
    _logger = logger;
  }
  
  public async Task<UserViewModel> CreateAsync(CreateUserDTO dto)
  {
    try
    {
      var createdUser = await _userRepository.SaveAsync(dto);

      return UserViewModel.ModelToViewModel(createdUser);
    }
    catch (Exception ex)
    {
      _logger.LogInformation("[USER SERVICE]: {}", ex.Message);
    }

    return null;
  }
}
