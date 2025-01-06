namespace AutoLend.Data.DataModels.Customer {
    public class CustomerGetByLicenseNumber {
        public int Id { get; set; }
        public required string LicenseNumber { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required bool HasActiveRental { get; set; }
    }
}
