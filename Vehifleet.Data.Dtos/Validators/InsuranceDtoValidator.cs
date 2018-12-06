using FluentValidation;

namespace Vehifleet.Data.Dtos.Validators
{
    public class InsuranceDtoValidator : AbstractValidator<InsuranceDto>
    {
        public InsuranceDtoValidator()
        {
            RuleFor(dto => dto.Id)
               .GreaterThanOrEqualTo(0)
               .WithMessage("Invalid Id.");

            RuleFor(dto => dto.VehicleId)
               .GreaterThanOrEqualTo(1)
               .WithMessage("Invalid vehicle Id.");

            RuleFor(dto => dto.StartDate)
               .LessThan(dto => dto.EndDate)
               .WithMessage("End date cannot be smaller than start date.");
        }
    }
}