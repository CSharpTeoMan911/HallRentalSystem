namespace HallRentalSystem.Classes.API_Parameters
{
    public class Halls_Pagination
    {
        public int page_index { get; set; }
        public List<string>? previous_pages_tokens { get; set; }
        public string? current_page_token { get; set; }
        public string? next_page_token { get; set; }
        public string? location_filter { get; set; }
    }
}
