using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace AbuDhabiPorts_BackEndApi.ViewModels.Employees;

public class AddEmployeeViewModel : IValidatableObject
{
    public string FullName { get; set; }
    public string JobTitle { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public double Salary { get; set; }
    public string Address { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validator = new AddEmployeeViewModelValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            yield return new ValidationResult(result.Errors.FirstOrDefault()?.ErrorMessage);
        }
    }

    public class AddEmployeeViewModelValidator : AbstractValidator<AddEmployeeViewModel>
    {
        public AddEmployeeViewModelValidator()
        {
            RuleFor(c => c.FullName)
                .NotEmpty()
                .WithMessage("Full Name is required");

            RuleFor(c => c.JobTitle)
               .NotEmpty()
               .WithMessage("Last Name is required");

            RuleFor(c => c.Gender)
               .NotEmpty()
               .WithMessage("GenderId is required");
            RuleFor(c => c.DateOfBirth)
              .NotEmpty()
              .WithMessage("DateOfBirth is required");
            RuleFor(c => c.Salary)
              .NotEmpty()
              .WithMessage("Salary is required");
            RuleFor(c => c.Address)
             .NotEmpty()
             .WithMessage("Address is required");
        }
    }
}