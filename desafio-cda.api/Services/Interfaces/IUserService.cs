using desafio_cda.api.DTO;
using desafio_cda.api.ViewModels;

namespace desafio_cda.api.Services.Interfaces;

public interface IUserService
{
  Task<UserViewModel> CreateAsync(CreateUserDTO dto);
}
