using BusyBee.Core.Models.Review;
using FluentValidation;

namespace BusyBee.Core.Validators.Review;

public class ReviewCommandValidator : AbstractValidator<ReviewCommand>
{
    public ReviewCommandValidator()
    {
        RuleFor(x => x.Politeness)
            .InclusiveBetween(1, 5);

        RuleFor(x => x.QualityOfWork)
            .InclusiveBetween(1, 5);

        RuleFor(x => x.Punctuality)
            .InclusiveBetween(1, 5);
    }
}