using LibraryBusiness.Interface.Repository;
using LibraryBusiness.Model;
using LibraryData.LibraryContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Repository
{
    public class LoanRepository : BaseRepository<Loan>, ILoanRepository
    {
        public LoanRepository(LibraryDbContext context) : base(context) { }

        public async Task<bool> MemberHasActiveLoans(Guid memberId)
        {
            return await _dbSet.AsNoTracking().Where(lo =>
            lo.MemberId == memberId
            && lo.ReturnDate != null
            && lo.IsActive).AnyAsync();
        }
    }
}
