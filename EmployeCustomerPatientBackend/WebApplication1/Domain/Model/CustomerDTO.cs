using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

      
        public string? Email { get; set; }


        public string? PhoneNumber { get; set; }

     
        public string? AddressLine1 { get; set; }

        
        public string? AddressLine2 { get; set; }

   
        public string? City { get; set; }

        
        public string? State { get; set; }

      
        public string? PostalCode { get; set; }


        public string? Country { get; set; }

       
        public DateTime DateOfBirth { get; set; }


        public string? Gender { get; set; }

        public DateTime AccountCreationDate { get; set; }

        public DateTime LastPurchaseDate { get; set; }

        public int TotalPurchaseAmount { get; set; }

        public int LoyaltyPoints { get; set; }


        public string? PreferredContactMethod { get; set; }

        public bool MarketingOptIn { get; set; }


        public string? CustomerType { get; set; }
        public bool isDeleted { get; set; }
    }
}
