using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Employee.EmployeeCommand
{
    public class UpdateEmployeeCommandcs : IRequest<object>
    {
        public EmployeeDTO EmployeeDTO { get; set; }
    }
    public class UpdateEmployeeCommandcsHandler : IRequestHandler<UpdateEmployeeCommandcs, object>
    {
        public readonly IAppDbContext _appDbContext;
        public UpdateEmployeeCommandcsHandler(IAppDbContext appdbContext)
        {
            _appDbContext = appdbContext;
        }

        public async Task<object> Handle(UpdateEmployeeCommandcs request, CancellationToken cancellationToken)
        {
            var empId = request.EmployeeDTO.EmployeeId;
            var emp = await _appDbContext.Set<Domain.Entity.Employee>().FindAsync(empId);
            if (emp is null) return null;

            emp.EmployeeId = request.EmployeeDTO.EmployeeId;
            emp.FirstName = request.EmployeeDTO.FirstName;
            emp.LastName = request.EmployeeDTO.LastName;
            emp.Email = request.EmployeeDTO.Email;
            emp.PhoneNumber = request.EmployeeDTO.PhoneNumber;
            emp.DateOfBirth = request.EmployeeDTO.DateOfBirth;
            emp.Gender = request.EmployeeDTO.Gender;
            emp.Address = request.EmployeeDTO.Address;
            emp.State = request.EmployeeDTO.State;
            emp.City = request.EmployeeDTO.City;
            emp.ZipCode = request.EmployeeDTO.ZipCode;
            emp.Country = request.EmployeeDTO.Country;
            emp.Department = request.EmployeeDTO.Department;
            emp.Position = request.EmployeeDTO.Position;
            emp.HireDate = request.EmployeeDTO.HireDate;
            emp.Salary = request.EmployeeDTO.Salary;
            emp.Manager = request.EmployeeDTO.Manager;
            emp.EmergencyContactName = request.EmployeeDTO.EmergencyContactName;
            emp.EmergencyContactPhone = request.EmployeeDTO.EmergencyContactPhone;
            emp.IsActive = request.EmployeeDTO.IsActive;
        

            //emp.DateOfBirth = request.StudentDTO.DateOfBirth;
            //emp.Email = request.StudentDTO.Email;


            await _appDbContext.SaveChangesAsync(cancellationToken);
            var response = new
            {
                status = 200,
                message = $"employee {empId} updated  successfuuly",
                empomerData = emp
            };
            return response;
            //ReturnType
            //return emp.Adapt<CustomerDTO>();





        }
    }
}
