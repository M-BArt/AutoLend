namespace AutoLend.Data.CoreModels.Customer {
    public class CustomerCreateDTO {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string LicenseNumber { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
