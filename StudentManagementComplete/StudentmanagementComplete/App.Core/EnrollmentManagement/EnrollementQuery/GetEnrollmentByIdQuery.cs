using App.Core.Interfaces;
using Domain.Entity;
using Domain.ModelDTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.EnrollmentManagement.EnrollementQuery
{
    public class GetEnrollmentByIdQuery : IRequest<List<Enrollment>>
    {
        public int Id { get; set; }
    }
    public class GetEnrollmentByIdQueryHandler : IRequestHandler<GetEnrollmentByIdQuery, List<Enrollment>>
    {
        public readonly IAppDbContext _appDbContext;
        public GetEnrollmentByIdQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Enrollment>> Handle(GetEnrollmentByIdQuery request, CancellationToken cancellationToken)
        {
            ////var stdId = request.StudentId;
            //var student = await _appDbContext.Set<Domain.Entity.Student>()
            //    .Include(e => e.Enrollment)
            //    .FirstOrDefaultAsync(e => e.StudentId == request.StudentId, cancellationToken);

            var enrollementid = request.Id;
            //var enrollementsdata = await _appDbContext.Set<Domain.Entity.Enrollment>().FindAsync(enrollementid);
            //if (enrollementsdata != null)
            //{

            //}
            var enrollmentData = await _appDbContext.Set<Domain.Entity.Enrollment>()
        .Include(e => e.Student) // Include the Student entity
        .Include(e => e.Courses) // Include the Courses entity
        .Where(e => e.StudentId == enrollementid)
        .ToListAsync(cancellationToken);

            return enrollmentData;
        }
    }


}
