using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }

     
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

       
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

 
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        
        public string Address { get; set; }

        public string City { get; set; }


        public string State { get; set; }


        public string ZipCode { get; set; }

    
        public string Country { get; set; }

        public string Department { get; set; }

  
        public string Position { get; set; }


        public DateTime HireDate { get; set; }


        public int Salary { get; set; }


        public string Manager { get; set; }

        public string EmergencyContactName { get; set; }


        public string EmergencyContactPhone { get; set; }


        public string EmergencyContactRelation { get; set; }

        public bool IsActive { get; set; }
    }
}
