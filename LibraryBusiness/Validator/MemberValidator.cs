using FluentValidation;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Validator
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {

            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is Required")
                .Length(2, 120)
                .WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");

        }
    }
}
