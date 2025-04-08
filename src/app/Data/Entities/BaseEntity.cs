using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Data.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
    }
    
    [Key]
    [Column("id", TypeName = "uuid")]
    public Guid Id { get; init; }

    [Column("CreatedTime", TypeName = "timestamp with time zone")]
    public DateTimeOffset CreatedTime { get; init; }

    [Column("CreatedBy", TypeName = "uuid")]
    public Guid? CreatedBy { get; init; }

    [Column("LastModifiedTime", TypeName = "timestamp with time zone")]
    public DateTimeOffset? LastModifiedTime { get; init; }

    [Column("ModifiedBy", TypeName = "uuid")]
    public Guid? ModifiedBy { get; init; }

    [Column("Deleted", TypeName = "bit")]
    public bool Deleted { get; set; }
}