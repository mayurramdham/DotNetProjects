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
    public class GetStudentByIdQuery:IRequest<StudentGetDTO>
    {     
        public int StudentId  { get; set; }
    }
    public class GetStudentByIdQueryHandler:IRequestHandler<GetStudentByIdQuery, StudentGetDTO>
    {
        public readonly IAppDbContext _appDbContext;
        public GetStudentByIdQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<StudentGetDTO> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            //var stdId = request.StudentId;
            var student= await _appDbContext.Set<Domain.Entity.Student>()
                .FirstOrDefaultAsync(e => e.StudentId==request.StudentId, cancellationToken);
            

            if (student == null)
            {
                return null;
            }
            return student.Adapt<StudentGetDTO>();
        }
    }
}
