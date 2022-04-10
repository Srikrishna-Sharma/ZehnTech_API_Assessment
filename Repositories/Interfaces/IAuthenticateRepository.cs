using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZehnTech_API_Assessment.Repositories.Interfaces
{
    public interface IAuthenticateRepository
    {
        public bool Validate(string UserName, string Password);
    }
}
