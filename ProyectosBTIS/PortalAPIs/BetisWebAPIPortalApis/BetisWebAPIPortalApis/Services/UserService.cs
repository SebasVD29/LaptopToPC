using BtisDataAccess.DAUsers;
using BtisEntities.EUsers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BetisWebAPIPortalApis.Services
{
    public interface IUserService
    {
        string Authenticate(EIUsers model);
        EIUsers GetUserChecked(string correo);
    }
    public class UserService : IUserService
    {
        readonly DAUsuarios _DAUsuarios = new DAUsuarios();

        private readonly EITokenSettings _appSettings;

        public UserService(IOptions<EITokenSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string Authenticate(EIUsers model)
        {
            var user = model;
            
            
            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            //EIToken eIToken = new EIToken { Token = token }; 

            return token;
        }

        private string GenerateJwtToken(EIUsers user)
        {
      
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.JWT_Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("IdUsuario", user.IdUsuario.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public EIUsers GetUserChecked(string correo)
        {

            return _DAUsuarios.Get_User_Checked(correo);

        }

        // helper methods

    }




}
