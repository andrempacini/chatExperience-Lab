using System;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Model;
using Controller;
using MySqlConnector;

    class Program {
        static void Main(string[] args) {

            //db connection
            string connectionString =  "Server=localhost,3306; User ID=root; Password=Silkroad@99; Database=chat_lab";
            using var connection = new MySqlConnection(connectionString);

            //testing chat options
            ChatMessages[] msg = [new ChatMessages(), new ChatMessages(), new ChatMessages()];
            msg[0].setOptions("Type 1 if you want to show users");
            msg[1].setOptions("Type 2 if you want to create a new user");
            msg[2].setOptions("type 3 if you want to Login");

            foreach (var option in msg) {
                Console.WriteLine(option.text);
            }
            var userOptionChoosed = Console.ReadLine();

            switch(userOptionChoosed) {

                //get a single user or all users from the system
                case "1":
                    Console.WriteLine("Type an user ID to search or '0' to bring a list with all users: ");
                    var userId = Console.ReadLine();
                    if (!userId.Contains('0')) {
                    var users = connection.Query<string>("SELECT username FROM users WHERE id = @userId", new { userId });
                    var user = connection.Get<User>(userId);
                    Console.WriteLine("Hello: " + user.username + " your password is: " + user.password );
                    } else {
                        var queryAllUsers = "SELECT * FROM users";
                        var getAllUsers = connection.Query(queryAllUsers);

                        Console.WriteLine("Those are all your users: ");
                        foreach(var user in getAllUsers) {
                            Console.WriteLine(user.username);
                        }
                    };
                    break;
                
                //create a new user
                case "2":
                    Console.WriteLine("Type a new user and password: ");
                    var newUsername = Console.ReadLine();
                    var newPassword = Console.ReadLine();

                    var newUser = new User {
                        username = newUsername!, password = newPassword!
                    };

                    connection.Insert<User>(newUser);
                    break;
                
                //user login
                case "3":
                    Console.WriteLine("Login screen still in development");
                    break;
            }

        }
    }

