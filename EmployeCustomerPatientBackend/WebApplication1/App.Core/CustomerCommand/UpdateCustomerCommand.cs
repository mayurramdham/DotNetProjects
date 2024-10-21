using Domain.Model;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CustomerCommand
{
    public class UpdateCustomerCommand : IRequest<object>
    {
        public CustomerDTO CustomerDTO { get; set; }
    }
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateCustomerCommand, object>
    {
        public readonly IAppDbContext _appDbContext;
        public UpdateStudentCommandHandler(IAppDbContext appdbContext)
        {
            _appDbContext = appdbContext;
        }

        public async Task<object> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var custId = request.CustomerDTO.CustomerID;
            var cust = await _appDbContext.Set<Domain.Entity.Customer>().FindAsync(custId);
            if (cust is null) return null;
          
                cust.CustomerID = request.CustomerDTO.CustomerID;
                cust.FirstName = request.CustomerDTO.FirstName;
                cust.LastName = request.CustomerDTO.LastName;
                cust.Email = request.CustomerDTO.Email;
                cust.PhoneNumber=request.CustomerDTO.PhoneNumber;
                cust.AddressLine1 = request.CustomerDTO.AddressLine1;
                cust.AddressLine2=request.CustomerDTO.AddressLine2;
                cust.PhoneNumber = request.CustomerDTO.PhoneNumber;
                cust.State = request.CustomerDTO.State;
                cust.PostalCode = request.CustomerDTO.PostalCode;
                cust.Country = request.CustomerDTO.Country;
                cust.DateOfBirth = request.CustomerDTO.DateOfBirth;
                cust.AccountCreationDate = request.CustomerDTO.AccountCreationDate;
                cust.LastPurchaseDate = request.CustomerDTO.LastPurchaseDate;
                cust.TotalPurchaseAmount=request.CustomerDTO.TotalPurchaseAmount;
                cust.LoyaltyPoints=request.CustomerDTO.LoyaltyPoints;
                cust.PreferredContactMethod=request.CustomerDTO.PreferredContactMethod;
                cust.MarketingOptIn=request.CustomerDTO.MarketingOptIn;
                cust.CustomerType=request.CustomerDTO.CustomerType;

                //cust.DateOfBirth = request.StudentDTO.DateOfBirth;
                //cust.Email = request.StudentDTO.Email;
               

                await _appDbContext.SaveChangesAsync(cancellationToken);
                var response = new
            {
                status = 200,
                message = $"Student {custId} updated  successfuuly",
                customerData = cust
            };
            return response;
            //ReturnType
            //return cust.Adapt<CustomerDTO>();





        }
    }
}
