
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoLend.Data.DataModels.Customer
{
    public class Customer
    {
        public string Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }  
        public string? FirstName { get; set; }       
        public string? LastName { get; set; }     
        public string? Email { get; set; }
        public string? LicenseNumber { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? HasActiveRental { get; set; }
    }
}
