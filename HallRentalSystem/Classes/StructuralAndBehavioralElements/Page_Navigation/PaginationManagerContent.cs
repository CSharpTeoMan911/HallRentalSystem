using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Page_Navigation
{
    public enum PaginationElements
    {
        AllElements,
        PreviousPageTokensElement,
        CurrentPageTokenElement,
        NextPageTokenElement
    }
    public class PaginationManagerContent
    {
        public ProtectedLocalStorage? LocalStorage { get; set; }
        public PaginationElements PaginationElement { get; set; }
        public List<string>? previous_page_tokens { get; set; }
        public string? current_page_token { get; set; }
        public string? next_page_token { get; set; }
    }
}
