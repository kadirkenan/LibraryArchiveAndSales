using FluentValidation;
using LibraryArchiveAndSales.Models.Dtos;

namespace LibraryArchiveAndSales.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required.");
            RuleFor(x => x.ISBN).NotEmpty().WithMessage("ISBN is required.");
        }
    }
}
