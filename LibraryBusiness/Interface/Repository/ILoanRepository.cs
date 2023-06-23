using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Interface.Repository
{
    public interface ILoanRepository : IBaseRepository<Loan>
    {
        public Task<bool> MemberHasActiveLoans(Guid memberId);
    }
}
