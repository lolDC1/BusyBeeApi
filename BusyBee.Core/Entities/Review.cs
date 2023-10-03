using BusyBee.Core.Common;

namespace BusyBee.Core.Entities;

public class Review : BaseAuditableEntity
{
    public string Text { get; set; } = null!;
    public int QualityOfWork { get; set; } // 1..5  
    public int Politeness { get; set; } // 1..5  
    public int Punctuality { get; set; } // 1..5 
    public Guid TaskId { get; set; }

    public Task Task { get; set; } = null!;
}