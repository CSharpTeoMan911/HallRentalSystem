﻿namespace HallRentalSystem.Classes
{
    public class Customer_ID_Value
    {
        public string? Customer_ID { get; set; }
        public string? Customer_First_Name { get; set; }
        public string? Customer_Middle_Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public class Customers:Dictionary<string, Customer_ID_Value> { }
}
