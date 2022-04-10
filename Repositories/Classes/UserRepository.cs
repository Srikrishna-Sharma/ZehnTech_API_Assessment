using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZehnTech_API_Assessment.DbContextFile;
using ZehnTech_API_Assessment.DTOs;
using ZehnTech_API_Assessment.Repositories.Domain;
using ZehnTech_API_Assessment.Repositories.Interfaces;

namespace ZehnTech_API_Assessment.Repositories.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly ZenTechDbContext _dbContext;
        
        public UserRepository(ZenTechDbContext dbContext)
        {
            _dbContext = dbContext;
            Mapper.CreateMap<UserDTO, User>().ReverseMap();

        }
        public async Task<UserDTO> GetUserProfile(string email)
        {
            var result=  await _dbContext.User.FindAsync(email);
            var response = Mapper.Map<UserDTO>(result);

            return response;
        }

        public bool SaveUser(UserDTO userdto)
        {
            var user = Mapper.Map<User>(userdto);
            _dbContext.User.Add(user);
            int rowsAffetcted = _dbContext.SaveChanges();
            return  rowsAffetcted>0?true:false;
        }
    }
}
