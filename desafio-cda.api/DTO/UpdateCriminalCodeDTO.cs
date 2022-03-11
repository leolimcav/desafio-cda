namespace desafio_cda.api.DTO;

public class UpdateCriminalCodeDTO
{
  public string Name { get; set; }
  public string Description { get; set; }
  public decimal Penalty { get; set; }
  public int PrisonTime { get; set; }
  public long CreateUserId { get; set; }
  public long UpdateUserId { get; set; }
  public long StatusId { get; set; }
}
