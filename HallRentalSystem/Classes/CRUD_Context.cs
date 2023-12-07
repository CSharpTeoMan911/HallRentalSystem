namespace HallRentalSystem.Classes
{
    public class CRUD_Context<InsertType, GetType, UpdateType, DeleteType, ReturnType> : CRUD_Strategy<InsertType, GetType, UpdateType, DeleteType, ReturnType>
    {
        private CRUD_Strategy<InsertType, GetType, UpdateType, DeleteType, ReturnType>? _Strategy;

        public CRUD_Context(CRUD_Strategy<InsertType, GetType, UpdateType, DeleteType, ReturnType> Strategy)
        {
            _Strategy = Strategy;
        }

        public Task<ReturnType> Delete(DeleteType? data)
        {
            if (_Strategy != null)
            {
                return _Strategy.Delete(data);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public Task<ReturnType> Get(GetType? data)
        {
            if (_Strategy != null)
            {
                return _Strategy.Get(data);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public Task<ReturnType> Insert(InsertType? data)
        {
            if (_Strategy != null)
            {
                return _Strategy.Insert(data);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public Task<ReturnType> Update(UpdateType? data)
        {
            if (_Strategy != null)
            {
                return _Strategy.Update(data);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
