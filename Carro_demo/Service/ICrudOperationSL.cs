using Carro_demo.Model;

namespace Carro_demo.Service
{
    public interface ICrudOperationSL
    {

        public Task<CreateUserRespones> CreateRecord(CreateUserRequest request);

        public Task<ReadRecordResponse> ReadRecord();

        public Task<LoginResponse> Login(LoginRequest request);

    }
}
