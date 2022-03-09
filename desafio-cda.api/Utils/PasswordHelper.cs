namespace desafio_cda.api.Utils;

public static class PasswordHelper
{
  public static string HashPassword(string password)
  {
    return BCrypt.Net.BCrypt.HashPassword(password);
  }

  public static bool CheckPassword(string password, string hashedPassword)
  {
    return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
  }
}
