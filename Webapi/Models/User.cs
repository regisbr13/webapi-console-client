using System.Collections.Generic;

namespace Webapi.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public List<Computer> Computers { get; set; }
    }
}