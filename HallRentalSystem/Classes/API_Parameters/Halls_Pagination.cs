namespace HallRentalSystem.Classes.API_Parameters
{
    public class Halls_Pagination
    {
        public int page_index { get; set; }
        public string? page_token { get; set; }
        public string? location_filter { get; set; }
    }
}
