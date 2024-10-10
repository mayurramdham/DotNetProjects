using App.Core.StudentManagement.StudentCommand;
using App.Core.StudentManagement.StudentQuery;
using App.Core.TeacherManagement.TeacherQuery;
using Domain.Entity;
using Domain.ModelDTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IMediator _mediatR;
        public readonly ILogger<StudentController> _logger;
        public StudentController(IMediator mediatR, ILogger<StudentController> logger)
        {
            _mediatR = mediatR;
            _logger = logger;
        }

        [HttpPost("CreateStudent")]
        public async Task<IActionResult> PostStudent(StudentDTO studentDTO)
        {
            
            var stdId = await _mediatR.Send(new AddStudentCommand { studentDTO = studentDTO });
            return Ok(stdId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentPost(StudentDTO studentDTO)
        {
            _logger.LogInformation("Student Created hit");
            var studentId = await _mediatR.Send(new CreateStudentCommand { studentDTO = studentDTO });
            return Ok(studentId);
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentList()
        {
            _logger.LogInformation("Get is executed");
            var studentList = await _mediatR.Send(new GetStudentsQuery {});
            return Ok(studentList);
            _logger.LogDebug("Index action was called at {studentList}", studentList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            _logger.LogInformation("Get ByID Called");
            var std = await _mediatR.Send(new GetStudentByIdQuery { StudentId = id });
            _logger.LogError("An error occurred at GetStudents", DateTime.UtcNow);

            return Ok(std);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateStudent(StudentDTO studentDTO)
        {
            var student=await _mediatR.Send(new UpdateStudentCommand { StudentDTO = studentDTO });
            return Ok(student);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student=await _mediatR.Send(new DeleteStudentCommand { id=id });
            return Ok(student);
        }
    }
}
