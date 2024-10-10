using App.Core.Interfaces;
using Domain.Entity;
using Domain.ModelDTO;
using Mapster;
using MediatR;

namespace App.Core.TeacherManagement.TeacherCommand
{
    public class CreateTeacherCommand : IRequest<int>
    {
        public TeacherDTO teacherDTO{ get; set; }
    }
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, int>
    {
        public readonly IAppDbContext _dbContext;
        public CreateTeacherCommandHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacherId =request.teacherDTO ;
            var teacher = teacherId.Adapt<Domain.Entity.Teacher>();
            await _dbContext.Set<Domain.Entity.Teacher>().AddAsync(teacher);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return teacher.TeacherId;
        }
    }
}
