using BookManagement.Features;
using FluentValidation;

namespace BookManagement.Validators;

public class UpdateBookValidator: AbstractValidator<UpdateBookRequest>
{
    public UpdateBookValidator()
    {
        RuleFor(x => x.Author).NotNull().NotEmpty().MinimumLength(3).WithMessage("Author must be at least 3 characters long.");
        RuleFor(x => x.Title).NotNull().NotEmpty().MinimumLength(3).WithMessage("Author must be at least 3 characters long.");
        RuleFor(x => x.YearPublished).GreaterThan(0).WithMessage("YearPublished must be a positive number.");

    }
}