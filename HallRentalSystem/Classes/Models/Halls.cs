namespace HallRentalSystem.Classes.Models
{
    public class Hall_ID_Value
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }
        public List<string>? Hall_Pictures { get; set; }
        public List<string>? Amenities { get; set; }
    }

    public class Halls:Dictionary<string, Hall_ID_Value> { }
}
