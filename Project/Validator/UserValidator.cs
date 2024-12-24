using FluentValidation;
using Project.Model;

namespace Project.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Last Name is required.");
            RuleFor(p => p.Email).EmailAddress();
        }

    }
}
