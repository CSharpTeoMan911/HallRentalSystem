namespace HallRentalSystem.Classes.Models
{
    public class Log_In_Session_ID_Value
    {
        public string? Log_In_Session_Key { get; set; }
        public string? Customer_ID { get; set; }
        public long Expiration_Date { get; set; }
    }

    public class Log_In_Sessions:Dictionary<string, Log_In_Session_ID_Value> { }
}
