namespace HallRentalSystem.Classes.API_Parameters
{
    public class Halls_Result
    {
        public string? halls { get; set; }
        public bool is_last { get; set; }
        public List<string>? previous_pages_tokens { get; set; }
        public string? current_page_token { get; set; }
        public string? next_page_token { get; set; }
    }
}
