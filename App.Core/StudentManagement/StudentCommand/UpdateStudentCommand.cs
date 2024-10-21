using App.Core.Interfaces;
using Domain.ModelDTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.StudentManagement.StudentCommand
{
    public class UpdateStudentCommand:IRequest<StudentDTO>
    {
        public StudentDTO StudentDTO { get; set; } 
    }
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, StudentDTO>
    {
        public readonly IAppDbContext _appDbContext;
        public UpdateStudentCommandHandler(IAppDbContext appdbContext)
        {
            _appDbContext = appdbContext;
        }

        public async Task<StudentDTO> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var stdId = request.StudentDTO.StudentId;
            var std=await _appDbContext.Set<Domain.Entity.Student>().FindAsync(stdId);
            if (std != null)
            {
                std.StudentId = request.StudentDTO.StudentId;
                std.Name = request.StudentDTO.Name;
                std.DateOfBirth= request.StudentDTO.DateOfBirth;
                std.Email= request.StudentDTO.Email;
               

                await _appDbContext.SaveChangesAsync(cancellationToken); 
                
            }

            return null;

        }
    }
}
