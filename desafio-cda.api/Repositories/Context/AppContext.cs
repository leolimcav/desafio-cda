using Microsoft.EntityFrameworkCore;

namespace desafio_cda.api.Repositories.Context;

public class UserContext: DbContext
{
  public UserContext(string connString) : base(connString)
  {
  }
}
