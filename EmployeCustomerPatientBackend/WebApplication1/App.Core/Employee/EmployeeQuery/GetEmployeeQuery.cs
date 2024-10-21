using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.EmployeeQuery
{
    public class GetEmployeeQuery : IRequest<object>
    {
    }
    public class GetStudentsQueryHandler : IRequestHandler<GetEmployeeQuery, object>
    {
        public readonly IAppDbContext _appDbContext;
        public GetStudentsQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<object> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Set<Domain.Entity.Employee>()
                 .AsNoTracking()
                 .ToListAsync();

            var response = new
            {
                status = 200,
                message = "All CustomerData",
                empList = list
            };
            return response;
        }
    }
}
