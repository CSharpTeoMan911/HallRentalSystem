using Microsoft.JSInterop;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements
{
    public class Animations
    {
        public enum Operation
        {
            Initiate,
            Clear
        }

        private static IJSObjectReference? _module = null;
        public Animations(IJSObjectReference module)
        {
            _module = module;
        }

        public async void ExpansionAnimation(Operation operation)
        {
            if (_module != null)
            {
                switch (operation)
                {
                    case Operation.Initiate:
                        await _module.InvokeAsync<string>("ExpansionAnimation", "index_page_jumbotron", "90", "10", "%");
                        break;
                    case Operation.Clear:
                        await _module.InvokeAsync<string>("ClearExpansionAnimation", "index_page_jumbotron");
                        break;
                }
            }
        }

        public async void ButtonAnimation(Operation operation, string element_id)
        {
            if (_module != null)
            {
                switch (operation)
                {
                    case Operation.Initiate:
                        await _module.InvokeAsync<string>("Set_Button_Focus_Effect", element_id);
                        break;
                    case Operation.Clear:
                        await _module.InvokeAsync<string>("Clear_Set_Button_Focus_Effect", element_id); await _module.InvokeAsync<string>("ClearExpansionAnimation", "index_page_jumbotron");
                        break;
                }
            }
        }

        public async void ElementResizeAnimation(Operation operation)
        {
            if (_module != null)
            {
                switch (operation)
                {
                    case Operation.Initiate:
                        await _module.InvokeAsync<string>("Set_Resize_Home_Page_Elements");
                        break;
                    case Operation.Clear:
                        await _module.InvokeAsync<string>("Clear_Resize_Home_Page_Elements");
                        break;
                }
            }
        }
    }
}
