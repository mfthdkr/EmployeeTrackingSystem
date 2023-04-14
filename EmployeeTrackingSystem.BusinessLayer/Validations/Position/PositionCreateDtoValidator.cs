using EmployeeTrackingSystem.CoreLayer.DTOs.Position;
using FluentValidation;

namespace EmployeeTrackingSystem.BusinessLayer.Validations.Position
{
    public class PositionCreateDtoValidator : AbstractValidator<PositionCreateDto>
    {
        public PositionCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.DepartmentId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
        }
    }
}
