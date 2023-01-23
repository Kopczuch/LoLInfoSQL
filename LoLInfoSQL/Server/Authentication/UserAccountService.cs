using MySql.Data.MySqlClient;

namespace LoLInfoSQL.Server.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> _userAccountList;

        public UserAccountService()
        {
            // Connect to the database
            using (var connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=lolinfodb_root;database=lolinfo"))
            {
                connection.Open();

                // Retrieve data from the data_loggin table
                using (var command = new MySqlCommand("SELECT * FROM dane_logowania", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        _userAccountList = new List<UserAccount>();
                        while (reader.Read())
                        {
                            _userAccountList.Add(new UserAccount
                            {
                                UserName = reader["nick"].ToString(),
                                Password = reader["haslo"].ToString(),
                                Role = reader["rola"].ToString()
                            });
                            Console.WriteLine(_userAccountList.Count);
                        }
                    }
                }
            }
        }

        public UserAccount? GetUserAccountByUserName(string userName)
        {
            return _userAccountList.FirstOrDefault(x => x.UserName == userName);
        }
    }
}