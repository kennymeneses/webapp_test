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

    [Column("created_time", TypeName = "timestamp with time zone")]
    public DateTimeOffset CreatedTime { get; init; }

    [Column("created_by", TypeName = "uuid")]
    public Guid? CreatedBy { get; init; }

    [Column("last_modified_time", TypeName = "timestamp with time zone")]
    public DateTimeOffset? LastModifiedTime { get; init; }

    [Column("modified_by", TypeName = "uuid")]
    public Guid? ModifiedBy { get; init; }

    [Column("deleted", TypeName = "boolean")]
    public bool Deleted { get; set; }
}