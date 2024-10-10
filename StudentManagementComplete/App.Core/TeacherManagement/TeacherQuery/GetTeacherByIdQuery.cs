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

namespace App.Core.TeacherManagement.TeacherQuery
{
    public class GetTeacherByIdQuery : IRequest<List<Teacher>>
    {
        public int TeacherId { get; set; }

       

    }
    public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, List<Teacher>>
    {
        private readonly IAppDbContext _context;

        public GetTeacherByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            // Fetch the teacher with related courses
            var stdId = request.TeacherId;
            var teacher = await _context.Set<Domain.Entity.Teacher>()
                .Include(t => t.Courses) // Include related courses
                .Where(t => t.TeacherId==stdId)
                .ToListAsync(cancellationToken);
                
            
                
               

            if (teacher == null)
            {
                return null; // Handle not found case
            }

            // Map the teacher entity to TeacherDTO using Mapster
            return teacher;

            
        }
    }


}
