using App.Core.Interfaces;
using Domain.ModelDTO;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CourseManagement
{
    public class CreateCourseCommand : IRequest<int>
    {
        public CourseDTO courseDTO  { get; set; }
    }
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
    {
        public readonly IAppDbContext _appDbContext;
        public CreateCourseCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var model = request.courseDTO;
            var courseData = model.Adapt<Domain.Entity.Courses>();
            if (courseData != null)
            {
                await _appDbContext.Set<Domain.Entity.Courses>().AddAsync(courseData);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            return courseData.CourseId;
        }
    }
}
