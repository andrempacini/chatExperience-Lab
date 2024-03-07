using System;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Models;
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
                        Console.WriteLine("These are all your users: ");
                        var users = userController.GetAllUsers();

                        foreach(var u in users) {
                            Console.WriteLine($"{u.username}");
                        }
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

                    //Get a single user
                    case "5":
                        Console.WriteLine("Type an user ID: ");
                        var user = userController.GetUserById();

                        foreach(var u in user) {
                            Console.WriteLine($"{u.username}");
                        }
                        break;

                }
                Console.WriteLine("\nFinished service. Type anything if you want to do keep on chating");

            }

        }
    }

