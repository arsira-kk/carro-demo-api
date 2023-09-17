namespace Carro_demo.Model
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<LoginData> LoginData { get; set; }
    }

    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class LoginData
    {
        public string username { get; set; }
        public string password { get; set; }

    }
}

