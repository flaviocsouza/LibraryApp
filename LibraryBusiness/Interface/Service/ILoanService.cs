using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Interface.Service
{
    public interface ILoanService
    {
        Task<decimal?> ComputeLateFee(Guid loanId);
        Task RenewLoan(Guid loanId);
        Task ReturnBook(Guid loanId);
        Task LendBook(Guid memberId, Guid bookId);
    }
}
