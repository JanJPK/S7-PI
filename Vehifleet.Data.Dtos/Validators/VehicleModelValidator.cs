using FluentValidation;

namespace Vehifleet.Data.Dtos.Validators
{
    public class VehicleModelValidator : AbstractValidator<VehicleModelDto>
    {
        public VehicleModelValidator()
        {
            RuleFor(dto => dto.Id)
               .GreaterThanOrEqualTo(0)
               .WithMessage("Invalid Id.");
        }
    }
}