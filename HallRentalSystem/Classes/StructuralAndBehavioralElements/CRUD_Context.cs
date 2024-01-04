namespace HallRentalSystem.Classes.StructuralAndBehavioralElements
{
    public class CRUD_Context<InsertType, GetType, UpdateType, DeleteType> : CRUD_Strategy<InsertType, GetType, UpdateType, DeleteType>
    {
        private CRUD_Strategy<InsertType, GetType, UpdateType, DeleteType>? _Strategy;

        public CRUD_Context(CRUD_Strategy<InsertType, GetType, UpdateType, DeleteType> Strategy)
        {
            _Strategy = Strategy;
        }


        public Task<ReturnType?> Delete<ReturnType>(DeleteType? data)
        {
            if (_Strategy != null)
            {
                return _Strategy.Delete<ReturnType>(data);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public Task<ReturnType?> Get<ReturnType>(GetType? data)
        {
            if (_Strategy != null)
            {
                return _Strategy.Get<ReturnType>(data);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public Task<ReturnType?> Insert<ReturnType>(InsertType? data)
        {
            if (_Strategy != null)
            {
                return _Strategy.Insert<ReturnType>(data);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public Task<ReturnType?> Update<ReturnType>(UpdateType? data)
        {
            if (_Strategy != null)
            {
                return _Strategy.Update<ReturnType>(data);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
