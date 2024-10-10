using App.Core.Interfaces;
using Domain.Entity;
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
    public class GetTeacherQuery:IRequest<List<Teacher>>
    {

    }
    public class GetTeacherQueryId:IRequestHandler<GetTeacherQuery,List<Teacher>>
    {
        public readonly IAppDbContext _appDbcontext;
        public GetTeacherQueryId(IAppDbContext appDbContext)
        {
         _appDbcontext = appDbContext;   
        }

        public async Task<List<Teacher>> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
        {
            var teacherData = _appDbcontext.Set<Domain.Entity.Teacher>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return teacherData.Adapt<List<Teacher>>();

        }
    }

}
