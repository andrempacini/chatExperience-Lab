using System.Net;
using Dapper;
using Dapper.Contrib.Extensions;
using Models;
using MySqlConnector;

namespace Controllers {
    public class UserController {
        private readonly MySqlConnection connection;
        public UserController(MySqlConnection conn) {
            connection = conn;
        }

        public List<User> GetAllUsers() {
            var getAllUsers = connection.Query<User>("SELECT * FROM users");

            Console.WriteLine("These are all your users: ");

            return getAllUsers.ToList();
        }

        public List<User> GetUserById() {
            var userId = Console.ReadLine();
            var users = connection.Query<User>("SELECT username FROM users WHERE id = @userId", new { userId });

            Console.WriteLine("User: ");
            
            return users.ToList();
        }

        public bool InsertUser() {
            Console.WriteLine("Type a new user name: ");
            var newUsername = Console.ReadLine();
            Console.WriteLine("Type a new password: ");
            var newPassword = Console.ReadLine();

            var newUser = new User {
                username = newUsername!, password = newPassword!
            };

            var response = connection.Insert<User>(newUser);

            return response > 0;
        }
    }
}