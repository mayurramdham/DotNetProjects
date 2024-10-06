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
    public class GetStudentsQuery:IRequest<List<Student>>
    {
       
    }
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery,List<Student>>
     {
        public readonly IAppDbContext _appDbContext;
        public GetStudentsQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;   
        }

        public async Task<List<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
           var list=await _appDbContext.Set<Domain.Entity.Student>()
                .AsNoTracking()
                .ToListAsync();
            return list.Adapt<List<Student>>();
        }
    }
}
