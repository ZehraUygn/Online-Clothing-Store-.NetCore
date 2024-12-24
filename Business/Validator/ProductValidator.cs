using Business.Models;
using FluentValidation;

namespace Business.Validator
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator() { 
        RuleFor(p => p.Size).NotEmpty().WithMessage("Size is required.");
        RuleFor(p => p.Price).NotEmpty().WithMessage("Price is required.");
        RuleFor(p => p.Color).NotEmpty().WithMessage("Color is required.");
        RuleFor(p => p.Stock_Quantity).NotEmpty().WithMessage("Quantity is required.");
    
        }
    }
}
