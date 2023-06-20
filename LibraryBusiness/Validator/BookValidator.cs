using FluentValidation;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Validator
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty()
                .WithMessage("{PropertyName} is Required")
                .Length(1, 80)
                .WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(b => b.ISBN)
                .NotEmpty()
                .WithMessage("{PropertyName} is Required")
                .Length(10, 13)
                .WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");

        }
    }
}
