namespace HallRentalSystem.Classes
{
    public interface CRUD_Strategy<InsertType, GetType, UpdateType, DeleteType, ReturnType>
    {
        public Task<ReturnType> Get(InsertType? data);
        public Task<ReturnType> Insert(GetType? data);
        public Task<ReturnType> Update(UpdateType? data);
        public Task<ReturnType> Delete(DeleteType? data);
    }
}
