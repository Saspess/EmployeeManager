using Application.Models.Employee;
using FluentValidation;
using Application.Validators.ValidationHelpers;

namespace Application.Validators.Emoloyee
{
    public abstract class EmployeeForManipulationModelValidator<T> : AbstractValidator<T> where T : EmployeeForManipulationModel
    {
        public EmployeeForManipulationModelValidator()
        {
            RuleFor(e => e.FirstName)
                .NotNull().WithMessage("First name is required field.");

            When(e => e.FirstName is not null, () =>
            {
                RuleFor(e => e.FirstName).Must(f => f.All(char.IsLetter)).WithMessage("First name must consist only of letters"); ;
            });

            RuleFor(e => e.LastName)
                .NotNull().WithMessage("Last name is required field.");

            When(e => e.LastName is not null, () =>
            {
                RuleFor(e => e.LastName).Must(l => l.All(char.IsLetter)).WithMessage("Last name must consist only of letters");
            });

            RuleFor(e => e.DepartmentName)
                .NotNull().WithMessage("Depatment name is required field.");

            RuleFor(e => e.PositionName)
                .NotNull().WithMessage("Position is required field.");

            RuleFor(e => e.Salary)
                .NotNull().WithMessage("Salary is required field.");

            When(e => e.Salary is not null, () =>
            {
                RuleFor(e => e.Salary)
                .GreaterThan(0).WithMessage("Salary must be greater than 0.");
            });

            RuleFor(e => e.Birthday)
                .NotNull().WithMessage("Birthday is required field.");

            When(e => e.Birthday is not null, () =>
            {
                RuleFor(e => e.Birthday).Must(DateValidator.IsDateValid).WithMessage("Birthday date must match dd.mm.yyyy.");
            });

            RuleFor(e => e.PhoneNumber)
                .NotNull().WithMessage("Phone number is required field.");

            When(e => e.PhoneNumber is not null, () =>
            {
                RuleFor(e => e.PhoneNumber).Must(PhoneValidator.IsPhoneValid).WithMessage("Phone number is invalid.");
            });

            RuleFor(e => e.City)
                .NotNull().WithMessage("City is required field.");

            RuleFor(e => e.Street)
                .NotNull().WithMessage("Street is required field.");

            RuleFor(e => e.HouseNumber)
                .NotNull().WithMessage("Building number is required field.");

            When(e => e.HouseNumber is not null, () =>
            {
                RuleFor(e => e.HouseNumber)
                .GreaterThan(0).WithMessage("Building number must be greater than 0.");
            });

            When(e => e.FlatNumber is not null, () =>
            {
                RuleFor(e => e.FlatNumber)
                .GreaterThan(0).WithMessage("Flat number must be greater than 0.");
            });

            RuleFor(e => e.InstitutionName)
                .NotNull().WithMessage("Institution name is required field.");

            RuleFor(e => e.StartYear)
                .NotNull().WithMessage("Start year is required field.");

            When(e => e.StartYear is not null, () =>
            {
                RuleFor(e => e.StartYear)
                    .GreaterThan(1950).WithMessage($"Start year must be greater than {DateTime.Now.Year - 70}")
                    .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"Start year must't be greater than {DateTime.Now.Year}");
            });

            RuleFor(e => e.EndYear)
                .NotNull().WithMessage("End year is required field.");

            When(e => e.EndYear is not null, () =>
            {
                RuleFor(e => e.EndYear)
                    .GreaterThan(1950).WithMessage($"End year must be greater than {DateTime.Now.Year - 70}")
                    .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"Start year must't be greater than {DateTime.Now.Year + 4}");
            });
        }
    }
}
