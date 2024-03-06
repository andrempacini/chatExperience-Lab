using System.Net;
using Dapper;
using Dapper.Contrib.Extensions;
using Models;
using MySqlConnector;

namespace Controllers {
    public class FeatureController {
        private readonly MySqlConnection connection;
        public FeatureController(MySqlConnection conn) {
            connection = conn;
        }

        public List<Feature> GetFeatures() {
            var queryFeatures = connection.Query<Feature>("SELECT * FROM features");
            
            return queryFeatures.ToList();
        }
    }
}