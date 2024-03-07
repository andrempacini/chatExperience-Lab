using System;
using Dapper.Contrib.Extensions;

namespace Models {
    [Table("users")]
    public class User {

        [Key]
        public int id {get; set;}
        public string username {get; set;}
        public string password {get; set;}
    }
}