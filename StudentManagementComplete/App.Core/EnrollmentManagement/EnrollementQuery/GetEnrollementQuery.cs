using App.Core.Interfaces;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.EnrollmentManagement.EnrollementQuery
{
    public class GetEnrollementQuery : IRequest<List<Enrollment>>
    {
    }
    public class GetEnrollementQueryHandler : IRequestHandler<GetEnrollementQuery, List<Enrollment>>
    {
        public readonly IAppDbContext _appDbContext;
        public GetEnrollementQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async  Task<List<Enrollment>> Handle(GetEnrollementQuery request, CancellationToken cancellationToken)
        {
            var enrollementData=await _appDbContext.Set<Domain.Entity.Enrollment>()
                .Include(e => e.Student) // Include the Student entity
                .Include(e => e.Courses)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return enrollementData;
                
        }
    }
}