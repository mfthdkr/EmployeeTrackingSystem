﻿using EmployeeTrackingSystem.CoreLayer.DTOs.Address;
using FluentValidation;

namespace EmployeeTrackingSystem.BusinessLayer.Validations.Address
{
    public class AddressDtoValidator : AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(x => x.City).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.FullAddress).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.EmployeeId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");

        }
    }
}
