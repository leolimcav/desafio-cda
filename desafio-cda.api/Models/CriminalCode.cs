using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace desafio_cda.api.Models;

[Table("criminalCodes")]
public class CriminalCode
{
  [Key, Column(name:"id")]
  public long Id { get; set; }
  [Column(name:"name", TypeName = "varchar")]
  public string Name { get; set; }
  [Column(name:"description", TypeName = "varchar")]
  public string Description { get; set; }
  [Column(name:"penalty", TypeName = "numeric(5, 2)")]
  public decimal Penalty { get; set; }
  [Column(name:"prisonTime", TypeName = "integer")]
  public int PrisonTime { get; set; }
  [ForeignKey(name:"statusId"), Column(name:"statusId")]
  public long StatusId { get; set; }
  public Status Status { get; set; }
  [ForeignKey(name:"createUserId"), Column(name:"createUserId")]
  public long CreateUserId { get; set; }
  public User CreateUser { get; set; }
  [ForeignKey(name:"updateUserId"), Column(name:"updateUserId")]
  public long UpdateUserId { get; set; }
  public User UpdateUser { get; set; }
  [Column(name:"createdAt", TypeName = "timestamp"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt { get; set; }
  [Column(name:"updatedAt", TypeName = "timestamp"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedAt { get; set; }
}
