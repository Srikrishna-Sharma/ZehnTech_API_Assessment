using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZehnTech_API_Assessment.Interfaces
{
    public interface IAuthenticationManager
    {
        public string Authenticate(string email, string password);
    }
}
