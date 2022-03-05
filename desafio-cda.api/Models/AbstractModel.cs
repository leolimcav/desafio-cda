namespace desafio_cda.api.Models;

public partial class AbstractModel
{
  public Guid Id { get; init; }
  public DateTime CreatedAt { get; init; }
  public DateTime UpdatedAt { get; init; }
}
