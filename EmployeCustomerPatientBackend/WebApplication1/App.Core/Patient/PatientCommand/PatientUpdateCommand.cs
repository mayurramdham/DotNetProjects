using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Patient.PatientCommand
{
    public class PatientUpdateCommand : IRequest<object>
    {
        public PatientDTO PatientDTO { get; set; }
    }
    public class PatientUpdateCommandHandler : IRequestHandler<PatientUpdateCommand, object>
    {
        public readonly IAppDbContext _appDbContext;
        public PatientUpdateCommandHandler(IAppDbContext appdbContext)
        {
            _appDbContext = appdbContext;
        }

        public async Task<object> Handle(PatientUpdateCommand request, CancellationToken cancellationToken)
        {
            var patientId = request.PatientDTO.PatientId;
            var patient = await _appDbContext.Set<Domain.Entity.Patient>().FindAsync(patientId);
            if (patient is null) return null;

            patient.PatientId = request.PatientDTO.PatientId;
            patient.FirstName = request.PatientDTO.FirstName;
            patient.MiddleName = request.PatientDTO.MiddleName;
            patient.LastName = request.PatientDTO.LastName;
            patient.age = request.PatientDTO.age;
            
            patient.Email = request.PatientDTO.Email;
            patient.PhoneNumber = request.PatientDTO.PhoneNumber;
            patient.Address = request.PatientDTO.Address;
            patient.City = request.PatientDTO.City;
            patient.State = request.PatientDTO.State;
            patient.PostalCode = request.PatientDTO.PostalCode;
        
            patient.Country = request.PatientDTO.Country;
            patient.DateOfBirth = request.PatientDTO.DateOfBirth;
            patient.EmergencyContactName = request.PatientDTO.EmergencyContactName;
            patient.EmergencyContactPhone = request.PatientDTO.EmergencyContactPhone;
            patient.InsuranceProvider = request.PatientDTO.InsuranceProvider;
            patient.InsurancePolicyNumber = request.PatientDTO.InsurancePolicyNumber;
            patient.MedicalHistory = request.PatientDTO.MedicalHistory;
            patient.DateOfRegistration = request.PatientDTO.DateOfRegistration;
            patient.Gender = request.PatientDTO.Gender;


            //patient.DateOfBirth = request.StudentDTO.DateOfBirth;
            //patient.Email = request.StudentDTO.Email;


            await _appDbContext.SaveChangesAsync(cancellationToken);
            var response = new
            {
                status = 200,
                message = $"patient {patientId} updated  successfuuly",
                patientomerData = patient
            };
            return response;
            //ReturnType
            //return patient.Adapt<PatientDTO>();





        }
    }
}
