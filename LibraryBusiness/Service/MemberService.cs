using LibraryBusiness.Interface.Notificator;
using LibraryBusiness.Interface.Service;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Service
{
    public class MemberService : BaseService, IMemberService
    {
        public MemberService(INotificator notificator) : base(notificator)
        {
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Member member)
        {
            throw new NotImplementedException();
        }

        public Task Update(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
