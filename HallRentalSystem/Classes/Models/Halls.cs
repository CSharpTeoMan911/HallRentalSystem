namespace HallRentalSystem.Classes.Models
{
    public class Hall_ID_Value
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public long Capacity { get; set; }
        public long Price { get; set; }
        public List<string>? Hall_Pictures { get; set; }
        public List<string>? Amenities { get; set; }
    }

    public class Halls:Dictionary<string, Hall_ID_Value> { }
}
