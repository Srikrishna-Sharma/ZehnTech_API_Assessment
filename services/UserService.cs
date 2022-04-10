using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZehnTech_API_Assessment.DTOs;
using ZehnTech_API_Assessment.Interfaces;
using ZehnTech_API_Assessment.Repositories.Interfaces;

namespace ZehnTech_API_Assessment.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDTO> GetUserProfile(string email)
        {
            var response=  await _userRepository.GetUserProfile(email);
            return response;
        }

        public bool SaveUser(UserDTO user)
        {
            return _userRepository.SaveUser(user);
        }
    }
}
