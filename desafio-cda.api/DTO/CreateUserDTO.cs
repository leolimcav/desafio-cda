using System.Text.Json.Serialization;

namespace desafio_cda.api.DTO;

public class CreateUserDTO
{
  public string UserName { get; set; }
  public string Password { get; set; }
}
