using System;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Model;
using MySqlConnector;
using Controllers;

class Program {
        static void Main(string[] args) {

            //db connection
            string connectionString =  "Server=localhost,3306; User ID=root; Password=Silkroad@99; Database=chat_lab";
            using var connection = new MySqlConnection(connectionString);

            var userController = new UserController(connection);
            var featureController = new FeatureController(connection);

            var leaveProgram = false;
            
            while(!leaveProgram) {
                var features = featureController.GetFeatures();

                foreach(var f  in features) {
                    Console.WriteLine($"{f.FeatureID}: {f.FeatureText}");
                }
                var userOptionChoosed = Console.ReadLine();

                switch(userOptionChoosed) {
                    //get a single user or all users from the system
                    case "3":
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
                    case "1":
                        userController.InsertUser();
                        break;
                    
                    //user login
                    case "2":
                        Console.WriteLine("Login screen still in development");
                        break;

                    //options menu
                    case "4":
                        leaveProgram = true;
                        break;

                }
                Console.WriteLine("Finished service. Type anything if you want to do keep on chating");

            }

        }
    }

