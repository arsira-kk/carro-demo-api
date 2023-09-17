namespace Carro_demo.Model
{
    public class ReadRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<ReadRecordData> readRecordData { get; set; }
    }

    public class ReadRecordData
    {
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string dateofbrith { get; set; }
        public string email { get; set; }
        public DateTime created_on { get; set; }

    }
    
}

