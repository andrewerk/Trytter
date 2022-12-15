using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public EModule Module { get; set; }
        public string Status { get; set; }
    }
}
