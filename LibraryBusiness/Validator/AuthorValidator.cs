using FluentValidation;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Validator
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is Required")
                .Length(2, 120)
                .WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");


            RuleFor(a => a.Nationality)
                .NotEmpty()
                .WithMessage("{PropertyName} is Required")
                .Length(2, 20)
                .WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");
        }
    }
}
