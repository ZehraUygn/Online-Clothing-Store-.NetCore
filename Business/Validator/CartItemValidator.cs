using Business.Models;
using FluentValidation;

namespace Business.Validator
{
    public class CartItemValidator: AbstractValidator<CartItemDto>
    {
        public CartItemValidator()
        {
            RuleFor(p => p.Size).NotEmpty().WithMessage("Size is required.");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Price is required.");
            RuleFor(p => p.Color).NotEmpty().WithMessage("Color is required.");
            RuleFor(p => p.Quantity).NotEmpty().WithMessage("Quantity is required.");
        }
    }
}
