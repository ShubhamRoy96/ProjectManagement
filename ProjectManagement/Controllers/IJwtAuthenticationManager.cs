using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public interface IJwtAuthenticationManager
    {
        public string Authenticate(string username, string password);
    }
}
