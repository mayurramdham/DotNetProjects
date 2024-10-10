using App.Core.StudentManagement.StudentCommand;
using App.Core.StudentManagement.StudentQuery;
using App.Core.TeacherManagement.TeacherQuery;
using Domain.Entity;
using Domain.ModelDTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Student_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IMediator _mediatR;
        public StudentController(IMediator mediatR) {
            _mediatR = mediatR;
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
            var studentId = await _mediatR.Send(new CreateStudentCommand { studentDTO = studentDTO });
            return Ok(studentId);
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentList()
        {
            var studentList = await _mediatR.Send(new GetStudentsQuery {});
            return Ok(studentList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var std = await _mediatR.Send(new GetStudentByIdQuery { StudentId = id });
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
