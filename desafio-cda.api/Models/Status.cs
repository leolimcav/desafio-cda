using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace desafio_cda.api.Models;

[Table("status")]
public class Status
{
  [Key, Column(name:"id")]
  public long Id { get; set; }
  [Column(name:"name", TypeName = "varchar")]
  public string Name { get; set; }
  [Column(name:"createdAt", TypeName = "timestamp"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt { get; set; }
  [Column(name:"updatedAt", TypeName = "timestamp"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedAt { get; set; }
}
