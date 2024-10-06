using App.Core.CourseManagement;
using Domain.ModelDTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public readonly IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpPost]
        public async Task<ActionResult> AddCourse(CourseDTO courseDTO)
        {
            var crsdata= await _mediator.Send(new CreateCourseCommand { courseDTO=courseDTO });
            return Ok(crsdata);
        }
    }
}
