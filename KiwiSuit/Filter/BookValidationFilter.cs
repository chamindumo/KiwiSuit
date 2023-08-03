using FluentValidation;
using java.awt.print;
using KiwiSuit.DTO;
using KiwiSuit.Models;

namespace KiwiSuit.Filter
{
    public class BookValidationFilter : IEndpointFilter
    {
        private readonly IValidator<BookDTO> _validator;

        public BookValidationFilter(IValidator<BookDTO> validator)
        {
            _validator = validator;

        }
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var book = context.Arguments.FirstOrDefault(a => a.GetType() == typeof(BookDTO)) as BookDTO;
            var result = await _validator.ValidateAsync(book);
            if (!result.IsValid) return Results.Json(result.Errors);

            return await next(context);
        }
    }
}
