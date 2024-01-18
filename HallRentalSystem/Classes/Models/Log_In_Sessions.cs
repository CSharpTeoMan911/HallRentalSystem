namespace HallRentalSystem.Classes.Models
{
    public class Log_In_Session_Value
    {
        public string? Customer_ID { get; set; }
        public DateTime? Expiration_Date { get; set; }
    }

    public class Log_In_Sessions:Dictionary<string, Log_In_Session_Value> { }
}
