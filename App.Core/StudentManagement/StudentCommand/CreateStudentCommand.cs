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

namespace App.Core.StudentManagement.StudentCommand
{
    public class CreateStudentCommand:IRequest<int>
    {
        public StudentDTO studentDTO;
    }
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        public readonly IAppDbContext _appDbContext;
        public CreateStudentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var model = request.studentDTO;
            var std=model.Adapt<Domain.Entity.Student>();
            if (std != null)
            {
                await _appDbContext.Set<Domain.Entity.Student>().AddAsync(std);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            return std.StudentId;
        }
    }
}
