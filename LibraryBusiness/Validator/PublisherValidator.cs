using FluentValidation;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Validator
{
    internal class PublisherValidator : AbstractValidator<Publisher>
    {
        public PublisherValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is Required")
                .Length(2, 80)
                .WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");

        }
    }
}
