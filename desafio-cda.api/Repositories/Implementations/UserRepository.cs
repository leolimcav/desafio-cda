using desafio_cda.api.DTO;
using desafio_cda.api.Models;
using desafio_cda.api.Repositories.Context;
using desafio_cda.api.Repositories.Interfaces;

using desafio_cda.api.Utils;

namespace desafio_cda.api.Repositories.Implementations;

public class UserRepository : IUserRepository
{
  private readonly AppDbContext _context;

  public UserRepository(AppDbContext context)
  {
    _context = context;
  }
  
  public async Task<User> SaveAsync(CreateUserDTO entity)
  {
    var createdUser = _context.Users.Add(new User
    {
      UserName = entity.UserName,
      Password = PasswordHelper.HashPassword(entity.Password),
    }).Entity;

    await _context.SaveChangesAsync();

    return createdUser;
  }
}
