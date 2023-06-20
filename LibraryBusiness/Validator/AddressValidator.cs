using FluentValidation;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Validator
{
    public class AddressValidator: AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Street)
                .NotEmpty()
                .WithMessage("{PropertyName} is Required")
                .Length(2, 80)
                .WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");


            RuleFor(a => a.City)
                .NotEmpty()
                .WithMessage("{PropertyName} is Required")
                .Length(2, 80)
                .WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");


            RuleFor(a => a.State)
                .NotEmpty()
                .WithMessage("{PropertyName} is Required")
                .Length(2, 80)
                .WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");


            RuleFor(a => a.PostalCode)
                .NotEmpty()
                .WithMessage("{PropertyName} is Required")
                .Length(6, 10)
                .WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");


            RuleFor(a => a.Phone)
                .NotEmpty()
                .WithMessage("{PropertyName} is Required")
                .Length(2, 80)
                .WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");

        }
    }
}
