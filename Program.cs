using System;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using MySqlConnector;


namespace MyApplication {
    class Program {
        static void Main(string[] args) {

            string connectionString =  "Server=localhost,3306; User ID=root; Password=Silkroad@99; Database=users";

            using var connection = new MySqlConnection(connectionString);

            var userId = Console.ReadLine();
            var users = connection.Query<string>("select user from usuarios where id = @userId", new { userId });

            var user = connection.Get<User>(userId);

            
            // Login loginMessage = new Login();

            // User userName = new User();


            // Console.WriteLine(loginMessage.login);
            Console.WriteLine("Hello: " + user.user + " your password is: " + user.password );


            Console.WriteLine("Type a new user and password: ");

            var newUsername = Console.ReadLine();
            var newPassword = Console.ReadLine();

            var newUser = new User {
                user = newUsername!, password = newPassword!
            };

            connection.Insert<User>(newUser);
        }
    }
}

