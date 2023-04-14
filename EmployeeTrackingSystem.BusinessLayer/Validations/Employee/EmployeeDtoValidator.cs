using EmployeeTrackingSystem.CoreLayer.DTOs.Employee;
using FluentValidation;

namespace EmployeeTrackingSystem.BusinessLayer.Validations.Employee
{
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Surname).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.DepartmentId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");

            RuleFor(x => x.PositionId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
        }

    }
}
