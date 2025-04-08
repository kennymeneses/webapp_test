using System.ComponentModel.DataAnnotations.Schema;
using app.Data.Entities.Enums;

namespace app.Data.Entities;

[Table("Users", Schema = "dbo")]
public class User : BaseEntity
{
    [Column("IdentificationNumber", TypeName = "uuid")]
    public string IdentificationNumber { get; set; }
    
    [Column("first_name", TypeName = "character varying")]
    public string FirstName { get; set; }
    
    [Column("last_name", TypeName = "character varying")]
    public string LastName { get; set; }
    
    [Column("email", TypeName = "character varying")]
    public string Email { get; set; }
    
    [Column("gender", TypeName = "integer")]
    public Gender Gender { get; set; }
    
    [Column("type", TypeName = "integer")]
    public UserType Type { get; set; }
    
    [Column("birthdate", TypeName = "date")]
    public DateOnly BirthDate { get; set; }
    
    public virtual UserPassword UserPassword { get; set; }
}