namespace BusyBee.Core.Models.Review;

public class ReviewResponse
{
    public string Text { get; set; } = null!;
    public int QualityOfWork { get; set; }
    public int Politeness { get; set; }
    public int Punctuality { get; set; }
    public Guid TaskId { get; set; }
}