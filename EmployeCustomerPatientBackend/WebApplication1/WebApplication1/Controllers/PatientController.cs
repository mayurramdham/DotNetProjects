using App.Core.CommandQuery;
using App.Core.CustomerCommand;
using App.Core.Patient.PatientCommand;
using App.Core.Patient.PatientQuery;
using App.Core.PatientCommand;
using Domain.Entity;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        public readonly IMediator _mediator;
        public PatientController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
            var Patient = await _mediator.Send(new AddPatientCommand { Patient = patient });
            return Ok(Patient);
        }

        [HttpGet]
        public async Task<IActionResult> GetPatient()
        {
            var patientList = await _mediator.Send(new GetPatientQuery { });
            return Ok(patientList);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatient(PatientDTO patientDTO)
        {
            var updatePatient = await _mediator.Send(new PatientUpdateCommand { PatientDTO = patientDTO });
            return Ok(updatePatient);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePatient(int Id)
        {
            var deletePatient = await _mediator.Send(new PatientDeleteCommand { id = Id });
            return Ok(deletePatient);
        }

    }
}
