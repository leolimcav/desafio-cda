using desafio_cda.api.Models;

namespace desafio_cda.api.ViewModels;

public class StatusViewModel
{
  public long Id { get; set; }

  public string Name { get; set; }

  public static StatusViewModel ModelToViewModel(Status model)
  {
    return new StatusViewModel()
    {
      Id = model.Id,
      Name = model.Name,
    };
  }
}
