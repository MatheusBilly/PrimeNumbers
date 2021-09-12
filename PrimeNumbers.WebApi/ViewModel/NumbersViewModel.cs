using FluentValidation;
using FluentValidation.Results;

namespace PrimeNumbers.WebApi.ViewModel
{
    public class NumbersViewModel
    {
        public int Number { get; set; }

        public ValidationResult Validate()
            => new NumbersViewModelValidation().Validate(this);
    }

    public class NumbersViewModelValidation : AbstractValidator<NumbersViewModel>
    {
        public NumbersViewModelValidation()
        {
            RuleFor(p => p.Number)
                .NotEmpty().WithMessage("Number is required")
                .LessThan(int.MaxValue).WithMessage("The maximun value is ${int.MaxValue}.")
                .GreaterThanOrEqualTo(0).WithMessage("Number must be greater than 0.");
        }
    }
}
