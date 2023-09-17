namespace Carro_demo.Model
{
    public class CreateUserRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string dateofbirth { get; set; }

    }
    public class CreateUserRespones
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
