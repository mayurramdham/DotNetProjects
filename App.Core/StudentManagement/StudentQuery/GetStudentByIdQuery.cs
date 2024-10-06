using App.Core.Interfaces;
using Domain.Entity;
using Domain.ModelDTO;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.StudentManagement.StudentQuery
{
    public class GetStudentByIdQuery:IRequest<Student>
    {
        public int StudentId  { get; set; }
    }
    public class GetStudentByIdQueryHandler:IRequestHandler<GetStudentByIdQuery,Student>
    {
        public readonly IAppDbContext _appDbContext;
        public GetStudentByIdQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async  Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var stdId=request.StudentId;
            var student = await _appDbContext.Set<Domain.Entity.Student>()
                .Include(e=>e.Enrollment)
                .ThenInclude(c=>c.Courses)
                .FirstOrDefaultAsync(e=>e.StudentId==stdId);
            if (stdId == null)
            {
                return null;
            }
          var studentMap= student.Adapt<Student>();
            return studentMap;
            
        }
    }
}
