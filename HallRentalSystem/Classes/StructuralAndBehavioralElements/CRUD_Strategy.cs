namespace HallRentalSystem.Classes.StructuralAndBehavioralElements
{
    public interface CRUD_Strategy<InsertType, GetType, UpdateType, DeleteType>
    {
        public Task<ReturnType?> Get<ReturnType>(GetType? data);
        public Task<ReturnType?> Insert<ReturnType>(InsertType? data);
        public Task<ReturnType?> Update<ReturnType>(UpdateType? data);
        public Task<ReturnType?> Delete<ReturnType>(DeleteType? data);
    }
}
