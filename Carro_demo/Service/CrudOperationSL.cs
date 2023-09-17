using Carro_demo.Model;
using Carro_demo.Repository;

namespace Carro_demo.Service
{
    public class CrudOperationSL : ICrudOperationSL
    {

        public readonly ICrudOperationRL _crudOperationRL;

        public CrudOperationSL(ICrudOperationRL crudOperationRL)
        {
            _crudOperationRL = crudOperationRL;        
        }
        public async Task<CreateUserRespones> CreateRecord(CreateUserRequest request)
        {
            return await _crudOperationRL.CreateRecord(request);
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            return await _crudOperationRL.ReadRecord();
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            return await _crudOperationRL.Login(request);
        }


    }
}
