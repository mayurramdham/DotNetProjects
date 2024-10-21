using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int EmployeeId { get; set; }


        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        
        public string Email { get; set; }

        [Required]
       
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
       
        public string? Gender { get; set; }

       
        public string? Address { get; set; }

      
        public string? City { get; set; }

      
       
        public string? State { get; set; }

       
        public string? ZipCode { get; set; }

   
        
        public string? Country { get; set; }

  
        public string? Department { get; set; }

        public string? Position { get; set; }

       
        public DateTime HireDate { get; set; }

        [Required]
        public int Salary { get; set; }

        public string? Manager { get; set; }


        public string? EmergencyContactName { get; set; }


        public string? EmergencyContactPhone { get; set; }

        public string? EmergencyContactRelation { get; set; }

        public bool IsActive { get; set; }

    }
}
