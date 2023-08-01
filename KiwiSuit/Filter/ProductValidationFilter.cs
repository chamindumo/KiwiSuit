using FluentValidation;
using KiwiSuit.DTO;

namespace KiwiSuit.Filter
{
    public class ProductValidationFilter : IEndpointFilter
    {
        private readonly IValidator<ProductDTO> _validator;


        public ProductValidationFilter(IValidator<ProductDTO> validator)
        {
            _validator = validator;

        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var product = context.Arguments.FirstOrDefault(a => a.GetType() == typeof(ProductDTO)) as ProductDTO;
            var result = await _validator.ValidateAsync(product);
            if (!result.IsValid) return Results.Json(result.Errors, statusCode: 400);

            return await next(context);
        }
    }
}
