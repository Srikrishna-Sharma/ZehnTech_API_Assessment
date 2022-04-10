using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZehnTech_API_Assessment.DbContextFile;
using ZehnTech_API_Assessment.Interfaces;
using ZehnTech_API_Assessment.Repositories.Interfaces;

namespace ZehnTech_API_Assessment.services
{
    public class AuthenticationManager : IAuthenticationManager
	{
        public string Secretkey = "Test_Key12345678987654334567"; //replace from configuration later
		private readonly ZenTechDbContext _dbContext;
		private readonly IAuthenticateRepository _authenticate;
		public AuthenticationManager(ZenTechDbContext dbContext, IAuthenticateRepository authenticate)
		{
			_dbContext = dbContext;
			_authenticate = authenticate;
		}
		public string Authenticate(string email, string password)
        {
			if (_authenticate.Validate(email,password))
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var tokenKey = Encoding.UTF8.GetBytes(Secretkey);
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new Claim[]
				  {
					new Claim(ClaimTypes.Name, email)
				  }),
					Expires = DateTime.UtcNow.AddMinutes(10),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
				};
				var token = tokenHandler.CreateToken(tokenDescriptor);
				return tokenHandler.WriteToken(token);
			}
			else return null;
        }
    }
}
