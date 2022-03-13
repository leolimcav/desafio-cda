using desafio_cda.api.Models;

namespace desafio_cda.api.ViewModels;

public class CriminalCodeViewModel
{
  public long Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public decimal Penalty { get; set; }
  public int PrisonTime { get; set; }
  public long StatusId { get; set; }
  public long CreateUserId { get; set; }
  public long UpdateUserId { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public static CriminalCodeViewModel ModelToViewModel(CriminalCode model)
  {
    return new CriminalCodeViewModel()
    {
      Id = model.Id,
      Name = model.Name,
      Description = model.Description,
      Penalty = model.Penalty,
      CreatedAt = model.CreatedAt,
      PrisonTime = model.PrisonTime,
      StatusId = model.StatusId,
      UpdatedAt = model.UpdatedAt,
      CreateUserId = model.CreateUserId,
      UpdateUserId = model.UpdateUserId
    };
  }
}
