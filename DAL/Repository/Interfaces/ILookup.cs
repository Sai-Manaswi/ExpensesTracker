using DAL.ExpenseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface ILookup
    {
        List<SP_GetLookupwithDetails_Result> SP_GetLookupwithDetails(bool pIsActive);
    }
}
