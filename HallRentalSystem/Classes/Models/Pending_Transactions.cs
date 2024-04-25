namespace HallRentalSystem.Classes.Models
{
    public class Pending_Transactions_Values
    {
        public string? Payment_Intent_ID { get; set; }
        public long? Expiration_Date { get; set; }
        public string? Customer_ID { get; set; }
        public string? Hall_ID { get; set; }
        public long Amount { get; set; }
        public List<DateOnly>? Rental_Dates { get; set; }
    }

    public class Pending_Transactions:Dictionary<string, Pending_Transactions_Values> { }
}
