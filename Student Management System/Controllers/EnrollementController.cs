using App.Core.EnrollmentManagement;
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
        public async Task<ActionResult<Enrollment>> CreateEnrollment(EnrollementDTO enrollment)
        {
            var enr = await _mediatR.Send(new CreateEnrollmentManagement { enrollementdto= enrollment });
            return Ok(enr);
        }
    }
}
