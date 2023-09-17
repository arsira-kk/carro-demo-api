using Carro_demo.Model;


namespace Carro_demo.Repository
{
    public interface ICrudOperationRL
    {
        public Task<CreateUserRespones> CreateRecord(CreateUserRequest request);
        public Task<ReadRecordResponse> ReadRecord();

        public Task<LoginResponse> Login(LoginRequest request);



    }
}
