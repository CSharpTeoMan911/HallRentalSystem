using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements
{
    public class HallsPaginationStateManager : CRUD_Strategy<PaginationManagerContent, PaginationManagerContent, PaginationManagerContent, PaginationManagerContent>
    {
        public async Task<ReturnType?> Delete<ReturnType>(PaginationManagerContent? data)
        {
            if (data?.LocalStorage != null)
            {
                switch (data?.PaginationElement)
                {
                    case PaginationElements.AllElements:
                        await data.LocalStorage.DeleteAsync("previous_page_tokens");
                        await data.LocalStorage.DeleteAsync("current_page_token");
                        await data.LocalStorage.DeleteAsync("next_page_token");
                        break;
                    case PaginationElements.PreviousPageTokensElement:
                        await data.LocalStorage.DeleteAsync("previous_page_tokens");
                        break;
                    case PaginationElements.CurrentPageTokenElement:
                        await data.LocalStorage.DeleteAsync("current_page_token");
                        break;
                    case PaginationElements.NextPageTokenElement:
                        await data.LocalStorage.DeleteAsync("next_page_token");
                        break;
                }
            }
            return (ReturnType?)(object?)data;
        }

        public async Task<ReturnType?> Get<ReturnType>(PaginationManagerContent? data)
        {
            if (data?.LocalStorage != null)
            {
                ProtectedBrowserStorageResult<List<string>>? previous_page_tokens = null;
                ProtectedBrowserStorageResult<string>? current_page_token = null;
                ProtectedBrowserStorageResult<string>? next_page_token = null;
                switch (data?.PaginationElement)
                {
                    case PaginationElements.AllElements:
                        previous_page_tokens = await data.LocalStorage.GetAsync<List<string>>("previous_page_tokens");
                        data.previous_page_tokens = previous_page_tokens?.Value;
                        current_page_token = await data.LocalStorage.GetAsync<string>("current_page_token");
                        data.current_page_token = current_page_token?.Value;
                        next_page_token = await data.LocalStorage.GetAsync<string>("next_page_token");
                        data.next_page_token = next_page_token?.Value;
                        break;
                    case PaginationElements.PreviousPageTokensElement:
                        previous_page_tokens = await data.LocalStorage.GetAsync<List<string>>("previous_page_tokens");
                        data.previous_page_tokens = previous_page_tokens?.Value;
                        break;
                    case PaginationElements.CurrentPageTokenElement:
                        current_page_token = await data.LocalStorage.GetAsync<string>("current_page_token");
                        data.current_page_token = current_page_token?.Value;
                        break;
                    case PaginationElements.NextPageTokenElement:
                        next_page_token = await data.LocalStorage.GetAsync<string>("next_page_token");
                        data.next_page_token = next_page_token?.Value;
                        break;
                }
            }
            return (ReturnType?)(object?)data;
        }

        public async Task<ReturnType?> Insert<ReturnType>(PaginationManagerContent? data)
        {
            if (data?.LocalStorage != null)
            {
                switch (data?.PaginationElement)
                {
                    case PaginationElements.AllElements:
                        if (data.previous_page_tokens != null && data.current_page_token != null && data.next_page_token != null)
                        {
                            await data.LocalStorage.SetAsync("previous_page_tokens", data.previous_page_tokens);
                            await data.LocalStorage.SetAsync("current_page_token", data.current_page_token);
                            await data.LocalStorage.SetAsync("next_page_token", data.next_page_token);
                        }
                        break;
                    case PaginationElements.PreviousPageTokensElement:
                        if (data.previous_page_tokens != null)
                            await data.LocalStorage.SetAsync("previous_page_tokens", data.previous_page_tokens);
                        break;
                    case PaginationElements.CurrentPageTokenElement:
                        if (data.current_page_token != null)
                            await data.LocalStorage.SetAsync("current_page_token", data.current_page_token);
                        break;
                    case PaginationElements.NextPageTokenElement:
                        if (data.next_page_token != null)
                            await data.LocalStorage.SetAsync("next_page_token", data.next_page_token);
                        break;
                }
            }
            return (ReturnType?)(object?)data;
        }

        public async Task<ReturnType?> Update<ReturnType>(PaginationManagerContent? data)
        {
            if (data?.LocalStorage != null)
            {
                switch (data?.PaginationElement)
                {
                    case PaginationElements.AllElements:
                        if (data.previous_page_tokens != null && data.current_page_token != null && data.next_page_token != null)
                        {
                            await data.LocalStorage.SetAsync("previous_page_tokens", data.previous_page_tokens);
                            await data.LocalStorage.SetAsync("current_page_token", data.current_page_token);
                            await data.LocalStorage.SetAsync("next_page_token", data.next_page_token);
                        }
                        break;
                    case PaginationElements.PreviousPageTokensElement:
                        if (data.previous_page_tokens != null)
                            await data.LocalStorage.SetAsync("previous_page_tokens", data.previous_page_tokens);
                        break;
                    case PaginationElements.CurrentPageTokenElement:
                        if (data.current_page_token != null)
                            await data.LocalStorage.SetAsync("current_page_token", data.current_page_token);
                        break;
                    case PaginationElements.NextPageTokenElement:
                        if (data.next_page_token != null)
                            await data.LocalStorage.SetAsync("next_page_token", data.next_page_token);
                        break;
                }
            }
            return (ReturnType?)(object?)data;
        }
    }
}
