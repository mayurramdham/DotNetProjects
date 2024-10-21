using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.PatientCommand
{
    public class AddPatientCommand : IRequest<object>
    {
        public Domain.Entity.Patient Patient { get; set; }
    }
    public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, object>
    {
        public readonly IAppDbContext _appDbContext;
        public AddPatientCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<object> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            var patientdata = request.Patient;
            //var empomer = empomerId.Adapt<Domain.Entity.Customer>();

            await _appDbContext.Set<Domain.Entity.Patient>().AddAsync(patientdata);
            var data = await _appDbContext.SaveChangesAsync(cancellationToken);
            var response = new
            {
                status = 200,
                Message = "Patient Addedd successfully",
                data = patientdata
            };
            return response;
        }
    }
}
