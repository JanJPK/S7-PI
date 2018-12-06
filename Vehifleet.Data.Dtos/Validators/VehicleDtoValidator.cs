using FluentValidation;

namespace Vehifleet.Data.Dtos.Validators
{
    public class VehicleDtoValidator : AbstractValidator<VehicleDto>
    {
        public VehicleDtoValidator()
        {
            RuleFor(dto => dto.Id)
               .GreaterThanOrEqualTo(0)
               .WithMessage("Invalid Id.");
        }
    }
}