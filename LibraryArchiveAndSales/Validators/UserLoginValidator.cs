using FluentValidation;
using LibraryArchiveAndSales.Models.Dtos;

namespace LibraryArchiveAndSales.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
        }
    }
}
