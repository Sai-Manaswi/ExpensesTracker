using DAL.ExpenseModel;
using DAL.Repository.Interfaces;
using DAL.Responses;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
//using static DAL.Responses.RequestResModel;

namespace DAL.Repository.Services
{
    public class LookupService : ILookup
    {
        ExpensesTrackerEntities1 context = new ExpensesTrackerEntities1();

        public List<SP_GetLookUpDropdowns_Result> SP_GetLookUpDropdowns(string name)
        {
            var lookup = context.SP_GetLookUpDropdowns(name).ToList();
            return lookup;
        }

        public List<SP_GetLookupwithDetails_Result> SP_GetLookupwithDetails(bool pIsActive)
        {
            var lookup = context.SP_GetLookupwithDetails(pIsActive).ToList();
            return lookup;
        }

        public ValueDataResponse<LookupReq> CreateLookUP(LookupReq lookup)
        {
            ValueDataResponse<LookupReq> response = new ValueDataResponse<LookupReq>();

            try
            {
                var existingLookup = context.Lookups.FirstOrDefault(l => l.Id == lookup.Id);

                if (existingLookup == null)
                {
                    // Creating a new Lookup
                    var newLookup = new Lookup
                    {
                        Name = lookup.Name,
                        IsActive = lookup.IsActive,
                        CreatedAt = DateTime.Now,
                        CreatedBy = lookup.CreatedBy,
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = lookup.UpdatedBy
                    };

                    context.Lookups.Add(newLookup);
                    context.SaveChanges();

                    lookup.Id = newLookup.Id;

                    if (lookup.LookUpDetailReq != null && lookup.LookUpDetailReq.Count > 0)
                    {
                        foreach (var lookupDetailReq in lookup.LookUpDetailReq)
                        {
                            var newLookupDetail = new LookUpDetail
                            {
                                LookUpId = newLookup.Id, // Use the newly created Lookup Id
                                Name = lookupDetailReq.Name,
                                Description = lookupDetailReq.Description,
                                IsActive = lookupDetailReq.IsActive,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now,
                                CreatedBy = lookupDetailReq.CreatedBy,
                                UpdatedBy = lookupDetailReq.UpdatedBy
                            };

                            context.LookUpDetails.Add(newLookupDetail);
                        }

                        context.SaveChanges();
                        response.IsSuccess = true;
                        response.EndUserMessage = "Lookup and LookupDetail(s) added successfully";
                    }
                    else
                    {
                        response.IsSuccess = true;
                        response.EndUserMessage = "Lookup added successfully, but no LookupDetail(s) provided";
                    }
                }

                else if (existingLookup != null)
                {
                    // Updating existing Lookup
                    existingLookup.Name = lookup.Name;
                    existingLookup.IsActive = true;
                    existingLookup.CreatedAt =existingLookup.CreatedAt;
                    existingLookup.CreatedBy = lookup.CreatedBy;
                    existingLookup.UpdatedAt = DateTime.Now;
                    existingLookup.UpdatedBy = lookup.UpdatedBy;

                    context.SaveChanges();

                    if (lookup.LookUpDetailReq != null && lookup.LookUpDetailReq.Count > 0)
                    {
                        foreach (var lookupDetailReq in lookup.LookUpDetailReq)
                        {

                            var existingLookupDetail = context.LookUpDetails.FirstOrDefault(ld => ld.Id == lookupDetailReq.Id);
                            if (existingLookupDetail != null)
                            {
                                existingLookupDetail.Name = lookupDetailReq.Name;
                                existingLookupDetail.Description = lookupDetailReq.Description;
                                existingLookupDetail.IsActive = lookupDetailReq.IsActive;
                                existingLookupDetail.UpdatedAt = DateTime.Now;
                                existingLookupDetail.UpdatedBy = lookupDetailReq.UpdatedBy;
                            }
                            else
                            {
                                var newLookupDetail = new LookUpDetail
                                {
                                    LookUpId = existingLookup.Id, // Use the existing Lookup Id
                                    Name = lookupDetailReq.Name,
                                    Description = lookupDetailReq.Description,
                                    IsActive = lookupDetailReq.IsActive,
                                    CreatedAt = DateTime.Now,
                                    UpdatedAt = DateTime.Now,
                                    CreatedBy = lookupDetailReq.CreatedBy,
                                    UpdatedBy = lookupDetailReq.UpdatedBy
                                };

                                context.LookUpDetails.Add(newLookupDetail);
                            }
                        }

                        context.SaveChanges();
                        response.IsSuccess = true;
                        response.EndUserMessage = "Lookup and LookupDetail(s) updated successfully";
                    }
                    else
                    {
                        response.IsSuccess = true;
                        response.EndUserMessage = "Lookup updated successfully";
                    }
                }

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                    }
                }

                response.IsSuccess = false;
                response.EndUserMessage = $"Validation error occurred while creating/updating the lookup.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.EndUserMessage = $"An error occurred while creating/updating the lookup: {ex.Message}";
            }

            return response;
        }

    }
}
