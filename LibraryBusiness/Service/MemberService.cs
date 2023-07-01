using LibraryBusiness.Interface.Notificator;
using LibraryBusiness.Interface.Repository;
using LibraryBusiness.Interface.Service;
using LibraryBusiness.Model;
using LibraryBusiness.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Service
{
    public class MemberService : BaseService, IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ILoanRepository _loanRepository;

        public MemberService(INotificator notificator,
            IMemberRepository memberRepository,
            ILoanRepository loanRepository
            ) : base(notificator)
        {
            _memberRepository = memberRepository;
            _loanRepository = loanRepository;
        }

        public async Task Insert(Member member)
        {
            if (!ExecuteValidation(new MemberValidator(), member) ||
                !ExecuteValidation(new AddressValidator(), member.Address)) return; 

            if((await _memberRepository.Find(m => m.Document == member.Document)).Any())
            {
                Notificate("A member already exists with the same document");
                return;
            }

            await _memberRepository.Insert(member);

        }

        public async Task Update(Member member)
        {
            if (!ExecuteValidation(new MemberValidator(), member) ||
                !ExecuteValidation(new AddressValidator(), member.Address)) return;

            if ((await _memberRepository.Find(m => m.Document == member.Document && m.Id != member.Id)).Any())
            {
                Notificate("A member already exists with the same document");
                return;
            }

            await _memberRepository.Update(member);
        }

        public async Task Delete(Guid id)
        {
            if(await _loanRepository.MemberHasActiveLoans(id))
            {
                Notificate("This member has outstanding Loans");
                return;
            }

            await _memberRepository.Delete(id);
        }
    }
}
