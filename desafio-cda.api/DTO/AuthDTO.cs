using System.Text.Json;
using System.Text.Json.Serialization;

namespace desafio_cda.api.DTO;

public class AuthDTO
{
  [JsonPropertyName("userName")]
  public string UserName { get; set; }
  [JsonPropertyName("password")]
  public string Password { get; set; }
}
