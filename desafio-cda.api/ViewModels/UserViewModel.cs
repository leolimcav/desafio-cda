using desafio_cda.api.Models;

namespace desafio_cda.api.ViewModels;

public class UserViewModel
{
  public long Id { get; set; }
  public string UserName { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public static UserViewModel ModelToViewModel(User model)
  {
    return new UserViewModel()
    {
      Id = model.Id, UserName = model.UserName, CreatedAt = model.CreatedAt, UpdatedAt = model.UpdatedAt
    };
  }
}
