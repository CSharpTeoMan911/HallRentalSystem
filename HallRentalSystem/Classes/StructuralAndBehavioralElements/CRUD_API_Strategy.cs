using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements
{
    public interface CRUD_API_Strategy<InsertType, GetType, UpdateType, DeleteType>
    {
        public Task<ActionResult<string>> Insert(InsertType? data);
        public Task<ActionResult<string>> Get(GetType? data);
        public Task<ActionResult<string>> Update(UpdateType? data);
        public Task<ActionResult<string>> Delete(DeleteType? data);
    }
}

