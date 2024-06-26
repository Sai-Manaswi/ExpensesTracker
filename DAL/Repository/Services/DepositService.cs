using DAL.ExpenseModel;
using DAL.Repository.Interfaces;
using DAL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Services
{
    public class DepositService : IDeposit

    {
        ExpensesTrackerEntities1 context = new ExpensesTrackerEntities1();

        public List<SP_GetDeposits_Result> SP_GetDeposits()
        {
            var expenses = context.SP_GetDeposits().ToList();
            return expenses;
        }

        public ValueDataResponse<Deposit> AddupdateDeposite(Deposit deposit)
        {
            ValueDataResponse<Deposit> response = new ValueDataResponse<Deposit>();

            try
            {
                var existingdata = context.Deposits.FirstOrDefault(s => s.Id == deposit.Id);

                if(existingdata == null)
                {
                    var obj = new Deposit
                    {
                        CreditDate = DateTime.Now,
                        Amount = deposit.Amount,
                        PaymentMethodId = deposit.PaymentMethodId,
                        CreditedBy = deposit.CreditedBy,
                        CreditedTo = deposit.CreditedTo,
                        Description = deposit.Description,
                        CarryForwardAmount = deposit.CarryForwardAmount,
                        CreatedBy = deposit.CreatedBy,
                        CreatedAt = DateTime.Now,
                        UpdatedBy = deposit.UpdatedBy,
                        UpdatedAt = deposit.UpdatedAt

                    };
                    context.Deposits.Add(obj);
                    context.SaveChanges();


                    response.IsSuccess = true;
                    response.EndUserMessage = "Data Added successfully";
                }

                else
                {
                    existingdata.Id = deposit.Id;
                    existingdata.CreditDate = existingdata.CreditDate;
                    existingdata.Amount = deposit.Amount;
                    existingdata.PaymentMethodId = deposit.PaymentMethodId;
                    existingdata.CreditedBy = deposit.CreditedBy;
                    existingdata.CreditedTo = deposit.CreditedTo;
                    existingdata.Description = deposit.Description;
                    existingdata.CarryForwardAmount = deposit.CarryForwardAmount;
                    existingdata.CreatedBy = deposit.CreatedBy;
                    existingdata.CreatedAt = existingdata.CreatedAt;
                    existingdata.UpdatedBy = deposit.UpdatedBy;
                    existingdata.UpdatedAt =DateTime.Now;

                    context.SaveChanges();

                    response.IsSuccess = true;
                    response.EndUserMessage = "Data Updated successfully";
                }
            }

            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.EndUserMessage = "Data failed to Add or Update :" + ex;
            }

            return response;
        }


        


    }
}
