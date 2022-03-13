using desafio_cda.api.DTO;
using desafio_cda.api.Models;

namespace desafio_cda.api.Repositories.Interfaces;

public interface IUserRepository
{
  Task<User?> GetByUsername(string userName);
  Task<User?> SaveAsync(CreateUserDTO entity);
}
