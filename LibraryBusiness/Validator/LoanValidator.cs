using FluentValidation;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Validator
{
    public class LoanValidator : AbstractValidator<Loan>
    {
        public LoanValidator()
        {
            //TODO: Think About LoanValidator.
            /*
             * As a rule, the loan will be registered at the time it is made
             * The field "LoanDate" must be Current Date
             * "DueDate" will be calculated by Service class 
             * So it's not necessary too
             * The "ReturnDate" originally will be null
             * (The system cannot know when the member will return the book) 
             * 
             */

        }
    }
}
