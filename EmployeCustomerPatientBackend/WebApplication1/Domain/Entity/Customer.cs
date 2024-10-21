using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

       
        public string? PhoneNumber { get; set; }

        [StringLength(100)]
        public string? AddressLine1 { get; set; }

        [StringLength(100)]
        public string? AddressLine2 { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [StringLength(50)]
        public string? State { get; set; }

        [StringLength(20)]
        public string? PostalCode { get; set; } //in ui it is number

        
        public string? Country { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        
      
        public string? Gender { get; set; }

        public DateTime AccountCreationDate { get; set; }

        public DateTime LastPurchaseDate { get; set; }

        public int TotalPurchaseAmount { get; set; } // in ui it is string

        public int LoyaltyPoints { get; set; } // string in ui

      
        public string? PreferredContactMethod { get; set; }

        public bool MarketingOptIn { get; set; } // string in ui

        
        public string? CustomerType { get; set; }
        public bool isDeleted { get; set; }
    }
}
