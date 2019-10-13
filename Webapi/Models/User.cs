using System.Collections.Generic;
using Access.Models;

namespace Webapi.Models
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public List<Computer> Computers { get; set; }
    }
}