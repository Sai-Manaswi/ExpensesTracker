using DAL.ExpenseModel;
using DAL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static DAL.Responses.RequestResModel;

namespace DAL.Repository.Interfaces
{
    public interface ILookup
    {
        List<SP_GetLookupwithDetails_Result> SP_GetLookupwithDetails(bool pIsActive);

        List<SP_GetLookUpDropdowns_Result> SP_GetLookUpDropdowns(string name);

        ValueDataResponse<LookupReq> CreateLookUP(LookupReq lookup);
    }
}
