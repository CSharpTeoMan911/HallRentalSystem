namespace HallRentalSystem.Classes
{
    public class Hall_ID
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }
        public List<string>? Hall_Pictures { get; set; }
        public List<string>? Amenities { get; set; }
    }
    public class Halls
    {
        public Dictionary<string, Hall_ID>? Hall_Id { get; set; }
    }
}
