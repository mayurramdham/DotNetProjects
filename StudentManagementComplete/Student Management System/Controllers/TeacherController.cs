using App.Core.StudentManagement.StudentQuery;
using App.Core.TeacherManagement.TeacherCommand;
using App.Core.TeacherManagement.TeacherQuery;
using Domain.Entity;
using Domain.ModelDTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        public readonly IMediator _mediator;
        public TeacherController(IMediator mediator) {
            _mediator = mediator;
                }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTeacherById(int id)
        {
            var std = await _mediator.Send(new GetTeacherByIdQuery { TeacherId = id });
            return Ok(std);
        }
        [HttpPost]
        public async Task<ActionResult> CreateTeacher(TeacherDTO teachers)
        {
            var teacher = await _mediator.Send(new CreateTeacherCommand {teacherDTO= teachers });
            return Ok(teacher);
        }
        [HttpGet]
        public async Task<ActionResult> GetTeacherList()
        {
            var teacher = await _mediator.Send(new GetTeacherQuery { });
            return Ok(teacher);
        }
    }
}
