using HallRentalSystem.Classes.StructuralAndBehavioralElements;

namespace HallRentalSystem.Classes
{
    public class HallsPaginationStateManager : CRUD_Strategy<string, string, string, string>
    {
        public Task<ReturnType?> Delete<ReturnType>(string? data)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnType?> Get<ReturnType>(string? data)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnType?> Insert<ReturnType>(string? data)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnType?> Update<ReturnType>(string? data)
        {
            throw new NotImplementedException();
        }
    }
}
