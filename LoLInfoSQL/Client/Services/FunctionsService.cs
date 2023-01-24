using System.Data;
using MySql.Data.MySqlClient;

namespace LoLInfoSQL.Client.Services
{
    public class FunctionsService
    {
        //private List<UserAccount> _userAccountList;

        public FunctionsService()
        {
            void CalculateWr(string functionName, string nick)
            {
                string connectionString = "server=127.0.0.1;uid=root;pwd=lolinfodb_root;database=lolinfo";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    if (string.IsNullOrEmpty(functionName))
                    {
                        throw new ArgumentException("Function name cannot be null or empty", "functionName");
                    }

                    if (string.IsNullOrEmpty(nick))
                    {
                        throw new ArgumentException("Nick cannot be null or empty", "nick");
                    }

                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(functionName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = functionName;
                        command.Parameters.AddWithValue("@nick", nick);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}