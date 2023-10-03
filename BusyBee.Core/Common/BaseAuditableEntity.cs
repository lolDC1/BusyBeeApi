using BusyBee.Core.Common.AutoAuditing;

namespace BusyBee.Core.Common;

public abstract class BaseAuditableEntity : BaseEntity, IAutoAudit
{
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}