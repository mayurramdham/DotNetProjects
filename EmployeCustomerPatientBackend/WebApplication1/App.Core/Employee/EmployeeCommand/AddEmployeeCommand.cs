using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.EmployeeCommand
{
    public class AddEmployeeCommand : IRequest<object>
    {
        public Domain.Entity.Employee Employee { get; set; }
    }
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, object>
    {
        public readonly IAppDbContext _appDbContext;
        public AddEmployeeCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<object> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeedata = request.Employee;
            //var empomer = empomerId.Adapt<Domain.Entity.Customer>();

            await _appDbContext.Set<Domain.Entity.Employee>().AddAsync(employeedata);
            var data = await _appDbContext.SaveChangesAsync(cancellationToken);
            var response = new
            {
                status = 200,
                Message = "Employee Added successfully",
                data = employeedata
            };
            return response;
        }
    }
}
