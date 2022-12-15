using FluentValidation;
using Application.Models.Department;
using Application.Validators.ValidationHelpers;

namespace Application.Validators.Department
{
    public abstract class DepartmentForManipulationModelValidator<T> : AbstractValidator<T> where T : DepartmentForManipulationModel
    {
        public DepartmentForManipulationModelValidator()
        {
            RuleFor(d => d.OrganizationName)
                .NotNull().WithMessage("Organizarion name is required field.");

            RuleFor(d => d.Name)
                .NotNull().WithMessage("Name is required field.");

            RuleFor(d => d.DirectorName)
                .NotNull().WithMessage("Director name is required field.");

            RuleFor(d => d.PhoneNumber)
                .NotNull().WithMessage("Phone number is required field.");

            When(d => d.PhoneNumber is not null, () =>
            {
                RuleFor(d => d.PhoneNumber).Must(PhoneValidator.IsPhoneValid).WithMessage("Phone number is invalid.");
            });

            RuleFor(d => d.City)
               .NotNull().WithMessage("City is required field.");

            RuleFor(d => d.Street)
                .NotNull().WithMessage("Street is required field.");

            RuleFor(d => d.HouseNumber)
                .NotNull().WithMessage("Building number is required field.");

            When(d => d.HouseNumber is not null, () =>
            {
                RuleFor(d => d.HouseNumber)
                .GreaterThan(0).WithMessage("Building number must be greater than 0.");
            });
        }
    }
}
