using Domain.Entity;
using Domain.Model;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CustomerCommand
{
    public class AddCustomerCommand : IRequest<object>
    {
        public Customer CustomerDTO { get; set; }
    }
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, object>
    {
        public readonly IAppDbContext _appDbContext;
        public AddCustomerCommandHandler(IAppDbContext appDbContext)
        { 
            _appDbContext = appDbContext;   
        }

        public async  Task<object> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var empomerdata = request.CustomerDTO;
            //var empomer = empomerId.Adapt<Domain.Entity.Customer>();
            empomerdata.isDeleted = false;
            await _appDbContext.Set<Domain.Entity.Customer>().AddAsync(empomerdata);
            var data=  await _appDbContext.SaveChangesAsync(cancellationToken);
            var response = new
            {
                status = 200,
                Message = "Customer Added successfully",
                data = empomerdata
            };
            return response;
        }
    }
}