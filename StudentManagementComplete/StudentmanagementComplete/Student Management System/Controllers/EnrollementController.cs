using App.Core.EnrollmentManagement;
using App.Core.EnrollmentManagement.EnrollementCommand;
using App.Core.EnrollmentManagement.EnrollementQuery;
using Domain.Entity;
using Domain.ModelDTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollementController : ControllerBase
    {
        public readonly IMediator _mediatR;
        public EnrollementController(IMediator mediatR)
        {
            _mediatR = mediatR;
                }
        [HttpPost]
        public async Task<ActionResult> CreateEnrollment(EnrollementDTO enrollment)
        {
            var enr = await _mediatR.Send(new CreateEnrollmentManagement { enrollementDTO=enrollment });
            return Ok(enr);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEnrollmentById(int id)
        {
            var enr = await _mediatR.Send(new GetEnrollmentByIdQuery { Id = id });
            return Ok(enr);
        }


        [HttpGet]
        public async Task<ActionResult> GetEnrollmentData()
        {
            var enrdatalist = await _mediatR.Send(new GetEnrollementQuery { });
            return Ok(enrdatalist);
        }
    }
}
