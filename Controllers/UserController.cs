using Dapper.Contrib.Extensions;
using Model;
using MySqlConnector;

namespace Controllers {
    public class UserController {
        private readonly MySqlConnection connection;
        public UserController(MySqlConnection conn) {
            connection = conn;
        }

        public bool InsertUser() {
            Console.WriteLine("Type a new user and password: ");
            var newUsername = Console.ReadLine();
            var newPassword = Console.ReadLine();

            var newUser = new User {
                username = newUsername!, password = newPassword!
            };

            var response = connection.Insert<User>(newUser);

            return response > 0;
        }
    }
}