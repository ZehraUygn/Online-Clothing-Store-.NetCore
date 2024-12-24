using FluentValidation;
using Business.Models;

namespace Project.Validator
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Last Name is required.");
            RuleFor(p => p.Email).EmailAddress();
        }
    }
}
