using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Patient.PatientCommand
{
    public class PatientDeleteCommand : IRequest<object>
    {
        public int id { get; set; }
    }
    public class PatientDeleteCommandHandler : IRequestHandler<PatientDeleteCommand, object>
    {
        public readonly IAppDbContext _appDbContext;
        public PatientDeleteCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<object> Handle(PatientDeleteCommand request, CancellationToken cancellationToken)
        {
            var patientId = request.id;
            var patient = await _appDbContext.Set<Domain.Entity.Patient>().FindAsync(patientId);
            if ((patient == null))
            {
                return null;

            }
            _appDbContext.Set<Domain.Entity.Patient>().Remove(patient);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            var response = new
            {
                status = 200,
                Message = $"Patient {patientId} deleted successfully",
                DeletedCustomer = patient
            };
            return response;
        }
    }
}
