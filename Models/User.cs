using System;
using Dapper.Contrib.Extensions;

namespace Model {
    [Table("users")]
    class User {

        [Key]
        public int id {get; set;}
        public string username {get; set;}
        public string password {get; set;}
    }
}