using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CommandQuery
{
    public class GetStudentsQuery : IRequest<List<Customer>>
    {
    }
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<Customer>>
    {
        public readonly IAppDbContext _appDbContext;
        public GetStudentsQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Customer>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Set<Domain.Entity.Customer>()
                .Where(c => c.isDeleted == false)
                 .AsNoTracking()
                 .ToListAsync();
            return list;
        }
    }
}
