using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace desafio_cda.api.Models;

[Table("users")]
public class User
{
  [Key, Column(name: "id")]
  public long Id { get; set; }
  [Column(name:"userName", TypeName = "varchar")]
  public string UserName { get; set; }
  [Column(name:"password", TypeName = "text")]
  public string Password { get; set; }
  [Column(name:"createdAt", TypeName = "timestamp"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt { get; set; }
  [Column(name:"updatedAt", TypeName = "timestamp"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
  public DateTime UpdatedAt { get; set; }
}
