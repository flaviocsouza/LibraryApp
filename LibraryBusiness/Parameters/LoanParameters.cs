using LibraryBusiness.Interface.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Parameters
{
    public class LoanParameters : ILoanParameters
    {
        public int GetDaysToDueDate()
        {
            return 10;
        }

        public decimal GetDailyLateFee()
        {
            return 3.5M;
        }
    }
}
