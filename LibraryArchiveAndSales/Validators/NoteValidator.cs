using FluentValidation;
using LibraryArchiveAndSales.Models.Dtos;

namespace LibraryArchiveAndSales.Validators
{
    public class NoteValidator : AbstractValidator<NoteDto>
    {
        public NoteValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().WithMessage("BookId is required.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required.");
        }
    }
}
