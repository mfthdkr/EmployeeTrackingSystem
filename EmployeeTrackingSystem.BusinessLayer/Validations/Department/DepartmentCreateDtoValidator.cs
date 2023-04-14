using EmployeeTrackingSystem.CoreLayer.DTOs.Department;
using FluentValidation;

namespace EmployeeTrackingSystem.BusinessLayer.Validations.Department
{
    public class DepartmentCreateDtoValidator : AbstractValidator<DepartmentCreateDto>
    {
        public DepartmentCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

        }
    }
}
