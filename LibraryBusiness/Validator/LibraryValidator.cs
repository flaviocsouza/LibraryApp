using FluentValidation;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Validator
{
    internal class LibraryValidator : AbstractValidator<Library>
    {
        public LibraryValidator()
        {
            RuleFor(l => l.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is Required")
                .Length(1, 80)
                .WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");
        }
    }
}
