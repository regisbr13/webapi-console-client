using System.Collections.Generic;
using Access.Models;

namespace Webapi.Models {
    public class User {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Computer> Computers { get; set; }
    }
}