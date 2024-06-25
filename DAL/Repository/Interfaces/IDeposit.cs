﻿using DAL.ExpenseModel;
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

        List<GetDeposits1_Result> GetDeposits1();

        ValueDataResponse<Deposit> AddupdateDeposite(Deposit deposit);


    }
}
