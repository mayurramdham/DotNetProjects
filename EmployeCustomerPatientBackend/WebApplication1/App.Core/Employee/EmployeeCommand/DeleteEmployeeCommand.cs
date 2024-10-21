using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Employee.EmployeeCommand
{
    public class DeleteEmployeeCommand : IRequest<object>
    {
        public int id { get; set; }
    }
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, object>
    {
        public readonly IAppDbContext _appDbContext;
        public DeleteEmployeeCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<object> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var empomerId = request.id;
            var empomer = await _appDbContext.Set<Domain.Entity.Employee>().FindAsync(empomerId);
            if ((empomer == null))
            {
                return null;

            }

            empomer.IsActive = true;
            _appDbContext.Set<Domain.Entity.Employee>().Remove(empomer);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            var response = new
            {
                status = 200,
                Message = $"Employee {empomerId}deleted successfully",
                DeletedCustomer = empomer
            };
            return response;
        }
    }
}
