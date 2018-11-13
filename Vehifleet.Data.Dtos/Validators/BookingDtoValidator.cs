using FluentValidation;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Data.Dtos.Validators
{
    public class BookingDtoValidator : AbstractValidator<BookingDto>
    {
        public BookingDtoValidator()
        {
            RuleFor(b => b.Id)
               .NotNull()
               .When(b => b.Status > BookingStatus.Created);

            RuleFor(b => b.StartDate)
               .LessThan(b => b.EndDate)
               .When(b => b.EndDate != null);

            RuleFor(b => b.EndDate)
               .NotNull()
               .When(b => b.Status >= BookingStatus.AwaitingReview);

            RuleFor(b => b.ManagerId)
               .NotNull()
               .When(b => b.Status >= BookingStatus.Submitted);

            RuleFor(b => b.Mileage)
               .NotNull()
               .When(b => b.Status >= BookingStatus.AwaitingReview);

            RuleFor(b => b.FuelConsumed)
               .NotNull()
               .When(b => b.Status >= BookingStatus.AwaitingReview);

            RuleFor(b => b.Cost)
               .NotNull()
               .When(b => b.Status >= BookingStatus.AwaitingReview);

            RuleFor(b => b.Notes)
               .NotNull()
               .NotEmpty()
               .When(b => b.Status >= BookingStatus.NeedsAdjustment);
        }
    }
}