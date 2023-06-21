using LibraryBusiness.Interface.Notificator;
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
        public LoanService(INotificator notificator) : base(notificator)
        {
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Loan loan)
        {
            throw new NotImplementedException();
        }

        public Task Update(Loan loan)
        {
            throw new NotImplementedException();
        }
    }
}
