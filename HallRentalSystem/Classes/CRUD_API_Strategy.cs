using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Classes
{
    public interface CRUD_API_Strategy<InsertType, GetType, UpdateType, DeleteType, ReturnType>
    {
        public Task<ActionResult<ReturnType>> Get(InsertType? data);
        public Task<ActionResult<ReturnType>> Insert(GetType? data);
        public Task<ActionResult<ReturnType>> Update(UpdateType? data);
        public Task<ActionResult<ReturnType>> Delete(DeleteType? data);
    }
}

