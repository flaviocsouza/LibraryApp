using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Interface.Service
{
    public interface IMemberService
    { 
        Task Insert(Member member);
        Task Update(Member member);
        Task Delete(Guid id);
    }
}

