using System.Data;

namespace AutoLend.Data.DataModels.Rental {
    public class Rental {
        public required int? Id { get; set; }
		public required DateTime CreateDate { get; set; }
        public required DateTime ModifyDate { get; set; }
        public required string LicensePlate { get; set; }
        public required string ModelName { get; set; }
        public required string BrandName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string LicenseNumber { get; set; }
        public required DateTime RentalDate { get; set; }
        public required DateTime ReturnDate { get; set; }
        public required string StatusName { get; set; }
        public required decimal TotalCost { get; set; }

    }
}
