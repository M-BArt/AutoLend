namespace AutoLend.Data.CoreModels.Rental {
    public class RentalUpdateDTO {
        public int RentalId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal? TotalCost { get; set; }
    }
}
