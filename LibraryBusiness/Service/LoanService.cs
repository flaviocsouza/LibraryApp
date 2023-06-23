using LibraryBusiness.Interface.Notificator;
using LibraryBusiness.Interface.Parameters;
using LibraryBusiness.Interface.Repository;
using LibraryBusiness.Interface.Service;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Service
{
    public class LoanService : BaseService, ILoanService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly ILoanParameters _loanParameters;

        public LoanService(INotificator notificator,
            IMemberRepository memberRepository,
            IBookRepository bookRepository,
            ILoanRepository loanRepository,
            ILoanParameters loanParameters) : base(notificator)
        {
            _memberRepository = memberRepository;
            _bookRepository = bookRepository;
            _loanRepository = loanRepository;
            _loanParameters = loanParameters;
        }

        public async Task LendBook(Guid memberId, Guid bookId)
        {

            if(_memberRepository.GetById(memberId).Result is null) Notificate("Member not Found");
            if(_bookRepository.GetById(bookId).Result is null) Notificate("Book not Found");
            if (!IsValid()) return;

            var newLoan = new Loan()
            {
                BookId = bookId,
                MemberId = memberId,
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(_loanParameters.GetDaysToDueDate()),
                ReturnDate = null
            };

            await _loanRepository.Insert(newLoan);
        }

        public async Task RenewLoan(Guid loanId)
        {
            var loanToRenew = await _loanRepository.GetById(loanId);
            
            if (!CheckExists(loanToRenew)) return;

            loanToRenew.DueDate = loanToRenew.DueDate.AddDays(10);
            await _loanRepository.Update(loanToRenew);
        }

        public async Task ReturnBook(Guid loanId)
        {
            var loanToComplete = await _loanRepository.GetById(loanId);

            if(!CheckExists(loanToComplete)) return;

            loanToComplete.ReturnDate = DateTime.Now;
            await _loanRepository.Update(loanToComplete);
        }

        public async Task<decimal?> ComputeLateFee(Guid loanId)
        {
            var overdueLoan = await _loanRepository.GetById(loanId);

            if(!CheckExists(overdueLoan)) return null;

            if (overdueLoan.ReturnDate == null) return ComputeFeeValue(overdueLoan.DueDate, DateTime.Now);

            return ComputeFeeValue(overdueLoan.DueDate, overdueLoan.ReturnDate.Value);
        }

        private decimal ComputeFeeValue(DateTime dueDate, DateTime lateDate)
        {
            if (lateDate < dueDate) return 0;

            var daysLate =  lateDate - dueDate;
            return (decimal)daysLate.TotalDays * _loanParameters.GetDailyLateFee();
        }
    }
}
