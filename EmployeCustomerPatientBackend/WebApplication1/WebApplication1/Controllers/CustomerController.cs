
using App.Core.CommandQuery;
using App.Core.CustomerCommand;
using Domain.Entity;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly IMediator _mediatR;
        public CustomerController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer empomerDTO)
        {
            var empomer = await _mediatR.Send(new AddCustomerCommand { CustomerDTO = empomerDTO });
            return Ok(empomer);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var empomerList = await _mediatR.Send(new GetStudentsQuery { });
            return Ok(empomerList);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerDTO empomerDTO)
        {
            var updateCustomer = await _mediatR.Send(new UpdateCustomerCommand { CustomerDTO = empomerDTO });
            return Ok(updateCustomer);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int Id)
        {
            var deleteCustomer = await _mediatR.Send(new DeleteCustomerCommand { id = Id });
            return Ok(deleteCustomer);
        }


    }
}
