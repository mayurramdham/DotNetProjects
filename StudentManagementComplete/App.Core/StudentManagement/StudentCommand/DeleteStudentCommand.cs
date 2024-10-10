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
    public class DeleteStudentCommand : IRequest<string>
    {
        public int id { get; set; }
    }
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, string>
    {
        public readonly IAppDbContext _appDbContext;
        public DeleteStudentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentId = request.id;
            var student = await _appDbContext.Set<Domain.Entity.Student>().FindAsync(studentId);
            if ((student==null))
            {
                return null;
                    
            }
            _appDbContext.Set<Domain.Entity.Student>().Remove(student);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return $"Student {studentId} Deleted  Sucessfully";

        }
    }

}
