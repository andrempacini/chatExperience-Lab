using System;
using Dapper.Contrib.Extensions;

namespace MyApplication {
    [Table("usuarios")]
    class User {

        [Key]
        public int id {get; set;}
        public string user {get; set;}
        public string password {get; set;}
    }
}