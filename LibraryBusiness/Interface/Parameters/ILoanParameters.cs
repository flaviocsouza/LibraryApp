using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Interface.Parameters
{
    public interface ILoanParameters
    {
        public int GetDaysToDueDate();
        public decimal GetDailyLateFee();
    }
}
