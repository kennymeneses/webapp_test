using System.ComponentModel.DataAnnotations.Schema;
using app.Data.Entities.Enums;

namespace app.Data.Entities;

[Table("UserPassword", Schema = "dbo")]
public class UserPassword : BaseEntity
{
    [Column("id", TypeName = "uuid")]
    public Guid UserId { get; set; }
    
    [Column("password", TypeName = "character varying")]
    public string Password { get; set; }
    
    public virtual User User { get; set; }
}