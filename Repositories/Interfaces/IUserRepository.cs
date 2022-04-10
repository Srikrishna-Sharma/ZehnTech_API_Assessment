using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZehnTech_API_Assessment.DTOs;

namespace ZehnTech_API_Assessment.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserDTO> GetUserProfile(string email);
        public bool SaveUser(UserDTO user);
    }
}
