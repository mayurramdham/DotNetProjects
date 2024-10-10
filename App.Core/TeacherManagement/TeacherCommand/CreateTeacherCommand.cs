using App.Core.Interfaces;
using Domain.Entity;
using Domain.ModelDTO;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.TeacherManagement.TeacherCommand
{
    public class CreateTeacherCommand:IRequest<int>
    {
        public TeacherDTO TeacherDTO{ get; set; } 
    }
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, int>
    {
        public readonly IAppDbContext _dbContext;
        public CreateTeacherCommandHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacherId=request.TeacherDTO;
            var teacher=teacherId.Adapt<Domain.ModelDTO.TeacherDTO>();
                 await _dbContext.Set<Domain.ModelDTO.TeacherDTO>().AddAsync(teacher);
                 await _dbContext.SaveChangesAsync(cancellationToken);
            return teacher.TeacherId;
        }
    }
}
