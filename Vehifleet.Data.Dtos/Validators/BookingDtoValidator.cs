using System;
using FluentValidation;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Data.Dtos.Validators
{
    public class BookingDtoValidator : AbstractValidator<BookingDto>
    {
        public BookingDtoValidator()
        {
            //RuleFor(b => b.Id)
            //   .GreaterThan(0)
            //   .When(b => b.Status > BookingStatus.Created)
            //   .WithMessage("Invalid employee Id.");

            RuleFor(b => b.VehicleId)
               .GreaterThan(0)
               .WithMessage("Invalid vehicle Id.");

            RuleFor(b => b.EmployeeId)
               .GreaterThan(0)
               .WithMessage("Invalid employee Id.");                                    

            RuleFor(b => b.StartDate)
               .LessThan(b => b.EndDate)
               .When(b => b.EndDate != null)
               .WithMessage("End date cannot be smaller than start date.");

            RuleFor(b => b.EndDate)
               .NotNull()
               .When(b => b.Status >= BookingStatus.Submitted)
               .WithMessage("Cannot submit booking request without end date.");

            RuleFor(b => b.ManagerId)
               .GreaterThan(0)
               .When(b => b.Status > BookingStatus.Submitted)
               .WithMessage("Manager Id cannot be empty for bookings past Submitted state.");

            RuleFor(b => b.Mileage)
               .NotNull()
               .GreaterThan(0)
               .When(b => b.Status >= BookingStatus.AwaitingReview)
               .WithMessage("Valid mileage must be submitted for bookings past Accepted state.");

            RuleFor(b => b.FuelConsumed)
               .NotNull()
               .GreaterThan(0)
               .When(b => b.Status >= BookingStatus.AwaitingReview)
               .WithMessage("Valid fuel consumption must be submitted for bookings past Accepted state.");

            RuleFor(b => b.Cost)
               .NotNull()
               .GreaterThan(0)
               .When(b => b.Status >= BookingStatus.AwaitingReview)
               .WithMessage("Valid cost must be submitted for bookings past Accepted state.");

            RuleFor(b => b.Notes)
               .NotNull()
               .NotEmpty()
               .When(b => b.Status >= BookingStatus.NeedsAdjustment)
               .WithMessage("Booking returned for adjustments must have a note.");
        }
    }
}