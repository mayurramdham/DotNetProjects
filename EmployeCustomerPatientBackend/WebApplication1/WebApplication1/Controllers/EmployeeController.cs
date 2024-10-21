using App.Core.CustomerCommand;
using App.Core.Employee.EmployeeCommand;
using App.Core.EmployeeCommand;
using App.Core.EmployeeQuery;
using Domain.Entity;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var empData = await _mediator.Send(new AddEmployeeCommand { Employee = employee });
            return Ok(empData);
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            var emp = await _mediator.Send(new GetEmployeeQuery { });
            return Ok(emp);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var updateemp = await _mediator.Send(new UpdateEmployeeCommandcs { EmployeeDTO = employeeDTO });
            return Ok(updateemp);
        }
        [HttpDelete]
        public async Task<IActionResult> Deleteemployee(int Id)
        {
            var deleteEmployee = await _mediator.Send(new DeleteEmployeeCommand { id = Id });
            return Ok(deleteEmployee);
        }
    }


}
