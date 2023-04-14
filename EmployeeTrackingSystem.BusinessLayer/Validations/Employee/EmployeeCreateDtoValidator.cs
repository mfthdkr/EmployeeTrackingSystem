using EmployeeTrackingSystem.CoreLayer.DTOs.Employee;
using FluentValidation;

namespace EmployeeTrackingSystem.BusinessLayer.Validations.Employee
{
    public class EmployeeCreateDtoValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Surname).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
             
        }

    }
}
