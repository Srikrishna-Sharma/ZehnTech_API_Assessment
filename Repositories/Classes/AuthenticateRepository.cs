using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZehnTech_API_Assessment.DbContextFile;
using ZehnTech_API_Assessment.Repositories.Interfaces;

namespace ZehnTech_API_Assessment.Repositories.Classes
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly ZenTechDbContext _dbContext;
        public AuthenticateRepository(ZenTechDbContext dbContext)
        {
           _dbContext = dbContext;
        }
        public bool Validate(string email, string Password)
        {
            if (_dbContext.User.Where(x => x.Email == email && x.Password == Password).Any())
                return true;
            else return false;           
        }
    }
}
