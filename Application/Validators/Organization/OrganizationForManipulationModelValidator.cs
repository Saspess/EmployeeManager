using Application.Models.Organization;
using Application.Validators.ValidationHelpers;
using FluentValidation;

namespace Application.Validators.Organization
{
    public abstract class OrganizationForManipulationModelValidator<T> : AbstractValidator<T> where T : OrganizationForManipulationModel
    {
        public OrganizationForManipulationModelValidator()
        {
            RuleFor(o => o.Name)
                .NotNull().WithMessage("Name is required field.");

            RuleFor(o => o.DirectorName)
                .NotNull().WithMessage("Director name is required field.");

            RuleFor(e => e.Email)
                .NotNull().WithMessage("Email is required field.");

            When(o => o.Email is not null, () =>
            {
                RuleFor(o => o.Email).EmailAddress().WithMessage("Email is invalid.");
            });

            RuleFor(e => e.PhoneNumber)
                .NotNull().WithMessage("Phone number is required field.");

            When(o => o.PhoneNumber is not null, () =>
            {
                RuleFor(o => o.PhoneNumber).Must(PhoneValidator.IsPhoneValid).WithMessage("Phone number is invalid.");
            });

            RuleFor(o => o.City)
                .NotNull().WithMessage("City is required field.");

            RuleFor(o => o.Street)
                .NotNull().WithMessage("Street is required field.");

            RuleFor(o => o.HouseNumber)
                .NotNull().WithMessage("Building number is required field.");

            When(o => o.HouseNumber is not null, () =>
            {
                RuleFor(o => o.HouseNumber)
                .GreaterThan(0).WithMessage("Building number must be greater than 0.");
            });
        }
    }
}
