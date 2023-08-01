using FluentValidation;
using KiwiSuit.DTO;
using KiwiSuit.Models;

namespace KiwiSuit.Validator
{
    public class BookDTOValidator : AbstractValidator<BookDTO>
    {
        public BookDTOValidator()
        {
            RuleFor(book => book.Id).GreaterThan(0);
            RuleFor(book => book.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(book => book.Author).NotEmpty().WithMessage("Author is required");


        }
    }
}
