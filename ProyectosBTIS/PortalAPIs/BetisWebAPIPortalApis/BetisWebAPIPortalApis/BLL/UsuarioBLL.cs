using BetisWebAPIPortalApis.Services;
using BtisDataAccess.DAUsers;
using BtisEntities;
using BtisEntities.EUsers;

namespace BetisWebAPIPortalApis.BLL
{
    public class UsuarioBLL
    {

        private readonly DAUsuarios _DAUsuarios = new DAUsuarios();
        private readonly IUserService _userService;
        public UsuarioBLL(IUserService userService)
        {
            _userService = userService;
        }

        public EIResponseUser GetUsersChecked(string correo)
        {
            try
            {

                var _User = _DAUsuarios.Get_User_Checked(correo);

                var _Token = _userService.Authenticate(_User);
                
                //Declaracion de objetos
                EIResponseUser responseUser = new EIResponseUser();

                _User.token = _Token;
                responseUser.usuario = _User;

                return responseUser;

             
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
