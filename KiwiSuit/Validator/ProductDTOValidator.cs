using FluentValidation;
using KiwiSuit.DTO;

namespace KiwiSuit.Validator
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(product => product.Id).GreaterThan(0);
            RuleFor(product => product.Names).NotEmpty().WithMessage("Names is required");
            RuleFor(product => product.Descriptions).NotEmpty().WithMessage("Descriptions is required");
        }
    }
}
