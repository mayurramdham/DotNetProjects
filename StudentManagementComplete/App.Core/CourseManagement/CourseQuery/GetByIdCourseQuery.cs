using App.Core.Interfaces;
using Domain.Entity;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CourseManagement.CourseQuery
{
    public class GetByIdCourseQuery:IRequest<Courses>
    {
        public int Id { get; set; }
    }
    public class GetByIdCourseQueryHandler:IRequestHandler<GetByIdCourseQuery,Courses>
    {
        public readonly IAppDbContext _appDbContext;
        public GetByIdCourseQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Courses> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
        {
            var courseId=request.Id;
            var courseData=await _appDbContext.Set<Domain.Entity.Courses>()
                .FirstOrDefaultAsync(c=>c.CourseId==courseId,cancellationToken);
            return courseData;

                
        }
    }

}
