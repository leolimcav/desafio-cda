namespace desafio_cda.api.Models;

public class CriminalCode: AbstractModel
{
  public String Name { get; set; }
  public String Description { get; set; }
  public Decimal Penalty { get; set; }
  public int PrisonTime { get; set; }
  public Guid StatusId { get; set; }
  public Guid CreateUserId { get; set; }
  public Guid UpdateUserId { get; set; }
}
