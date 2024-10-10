using App.Core.Interfaces;
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
    public class AddStudentCommand : IRequest<int>
    {
        public StudentDTO studentDTO { get; set; }
    }
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, int>
    {
        public readonly IAppDbContext _appDbContext;
        public AddStudentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var model = request.studentDTO;
            var stdData = model.Adapt<Domain.Entity.Student>();
            if (stdData != null)
            {
                await _appDbContext.Set<Domain.Entity.Student>().AddAsync(stdData);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            return stdData.StudentId;
        }
    }

}