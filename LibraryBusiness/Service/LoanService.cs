using LibraryBusiness.Interface.Repository;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Service
{
    public class LoanService : BaseService, ILoanRepository
    {
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Loan>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Loan?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Loan entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task Update(Loan entity)
        {
            throw new NotImplementedException();
        }
    }
}
