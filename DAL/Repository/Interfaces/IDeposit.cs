using DAL.ExpenseModel;
using DAL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IDeposit
    {

        List<SP_GetDeposits_Result> SP_GetDeposits();

        ValueDataResponse<Deposit> AddupdateDeposite(Deposit deposit);


    }
}
