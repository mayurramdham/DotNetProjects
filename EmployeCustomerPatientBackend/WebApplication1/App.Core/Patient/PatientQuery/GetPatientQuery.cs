using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Patient.PatientQuery
{
    public class GetPatientQuery : IRequest<object>
    {
    }
    public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, object>
    {
        public readonly IAppDbContext _appDbContext;
        public GetPatientQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<object> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Set<Domain.Entity.Patient>()
                 .AsNoTracking()
                 .ToListAsync();
            var response = new
            {
                status = 200,
                message = "Patient Data",
                customerData = list
            };
            return response;
        }
    }
}
