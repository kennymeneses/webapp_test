using System.ComponentModel.DataAnnotations.Schema;
using app.Data.Entities.Enums;

namespace app.Data.Entities;

[Table("Users", Schema = "dbo")]
public class User : BaseEntity
{
    [Column("IdentificationNumber", TypeName = "uuid")]
    public string IdentificationNumber { get; set; }
    
    [Column("FirstName", TypeName = "character varying")]
    public string FirstName { get; set; }
    
    [Column("LastName", TypeName = "character varying")]
    public string LastName { get; set; }
    
    [Column("Email", TypeName = "character varying")]
    public string Email { get; set; }
    
    [Column("Gender", TypeName = "integer")]
    public Gender Gender { get; set; }
    
    [Column("Type", TypeName = "integer")]
    public UserType Type { get; set; }
    
    [Column("BirthDate", TypeName = "date")]
    public DateOnly BirthDate { get; set; }
    
    public virtual UserPassword UserPassword { get; set; }
}