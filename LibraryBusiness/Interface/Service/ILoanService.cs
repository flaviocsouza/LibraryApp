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

        Task Insert(Loan loan);
        Task Update(Loan loan);
        Task Delete(Guid id);
    }
}
