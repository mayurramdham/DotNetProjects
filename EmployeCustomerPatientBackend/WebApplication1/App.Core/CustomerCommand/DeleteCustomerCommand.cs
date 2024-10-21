using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CustomerCommand
{
  public class DeleteCustomerCommand : IRequest<object>
    {
        public int id { get; set; }
    }
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, object>
    {
        public readonly IAppDbContext _appDbContext;
        public DeleteCustomerCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<object> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerId = request.id;
            var customer = await _appDbContext.Set<Domain.Entity.Customer>().FindAsync(customerId);
            if ((customer == null))
            {
                return null;

            }
            customer.isDeleted = true;
            //_appDbContext.Set<Domain.Entity.Customer>().Remove(customer);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            var response = new
            {
                status=200,
                Message = "Customer deleted successfully",
                DeletedCustomer = customer
            };
            return response;
        }
    } 
    }

