﻿namespace AutoLend.Data.DataModels.Rental {
    public class Rental {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsActive { get; set; }
    }
}
