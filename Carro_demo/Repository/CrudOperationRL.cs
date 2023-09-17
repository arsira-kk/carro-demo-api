using Carro_demo.Model;
using MySql.Data.MySqlClient;



namespace Carro_demo.Repository
{
    public class CrudOperationRL : ICrudOperationRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _sqlConnection;


        public CrudOperationRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new MySqlConnection(_configuration[key: "ConnectionStrings:DBSettingConnection"]);
        }
        public async Task<CreateUserRespones> CreateRecord(CreateUserRequest request)
        {
            CreateUserRespones respones = new CreateUserRespones();
            respones.IsSuccess = true;
            respones.Message = "Successful";
            try
            {
                string sqlquery = "INSERT INTO Account ( username, password,name,lastname,dateofbirth,email, created_on) " +
                    "Values ( @username, @password,@name,@lastname,@dateofbirth, @email,@created_on)";
                using (MySqlCommand sqlCommand = new MySqlCommand(sqlquery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@username", request.username);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@password", request.password);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@name", request.name);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@lastname", request.lastname);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@dateofbirth", request.dateofbirth);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@email", request.email);
                    sqlCommand.Parameters.AddWithValue("@created_on", DateTime.Now);
                    _sqlConnection.Open();

                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        respones.IsSuccess = false;
                        respones.Message = "Someting went Wrong";
                    }


                }

            }
            catch (Exception ex)
            {
                respones.IsSuccess = false;
                respones.Message = ex.Message;

            }
            finally
            {
                _sqlConnection.Close();
            }
            return respones;
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            ReadRecordResponse response = new ReadRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string sqlQuery = "Select   username, password,name,lastname,dateofbirth, email FROM Account; ";
                using (MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();
                    using (MySqlDataReader cmd = (MySqlDataReader)await sqlCommand.ExecuteReaderAsync())
                    {
                        if (cmd.HasRows)
                        {
                            response.readRecordData = new List<ReadRecordData>();
                            while (await cmd.ReadAsync())
                            {
                                ReadRecordData dbData = new ReadRecordData();
                                dbData.username = cmd[name: "username"] != DBNull.Value ? cmd[name: "username"].ToString() : string.Empty;
                                dbData.password = cmd[name: "password"] != DBNull.Value ? cmd[name: "password"].ToString() : string.Empty;
                                dbData.name = cmd[name: "name"] != DBNull.Value ? cmd[name: "name"].ToString() : string.Empty;
                                dbData.lastname = cmd[name: "lastname"] != DBNull.Value ? cmd[name: "lastname"].ToString() : string.Empty;
                                dbData.dateofbrith = cmd[name: "dateofbirth"] != DBNull.Value ? cmd[name: "dateofbirth"].ToString() : string.Empty;
                                dbData.email = cmd[name: "email"] != DBNull.Value ? cmd[name: "email"].ToString() : string.Empty;
                                response.readRecordData.Add(dbData);
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }


        public async Task<LoginResponse> Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();

            try
            {
                string sqlQuery = "Select  * FROM Account where username = @username and password = @password ; ";
                using (MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@username", request.username);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@password", request.password);
                    _sqlConnection.Open();
                    using (MySqlDataReader cmd = (MySqlDataReader)await sqlCommand.ExecuteReaderAsync())
                    {
                        if (cmd.HasRows)
                        {
                            response.LoginData = new List<LoginData>();
                            while (await cmd.ReadAsync())
                            {
                                LoginData dbData = new LoginData();
                                dbData.username = cmd[name: "username"] != DBNull.Value ? cmd[name: "username"].ToString() : string.Empty;
                                dbData.password = cmd[name: "password"] != DBNull.Value ? cmd[name: "password"].ToString() : string.Empty;
                                response.LoginData.Add(dbData);
                            }

                            response.IsSuccess = true;
                            response.Message = "Successful";
                        }
                        else {
                            response.IsSuccess = false;
                            response.Message = "Login false";
                        }
                    }
                }






            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }


    }
}
