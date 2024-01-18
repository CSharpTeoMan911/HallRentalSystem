namespace HallRentalSystem.Classes
{
    public class Customer_ID_Value
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class Customers:Dictionary<string, Customer_ID_Value> { }
}
