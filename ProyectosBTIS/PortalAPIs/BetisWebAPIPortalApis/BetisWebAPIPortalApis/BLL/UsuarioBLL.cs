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
        public UsuarioBLL( IUserService userService)
        {
            _userService = userService;
        }
        public int GetIdUserCorreo(String correo)
        {
            try
            {
                //Declaracion de objetos
                var idUsuario = _DAUsuarios.GetIdUserCorreo(correo);
                if (idUsuario != 0)
                {
                    return idUsuario;

                }
                else
                {
                    return 0; //error 0 el usuario no existe
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        
        public EIResponseUser GetUsersId(int id)
        {
            try
            {

                var _User = _DAUsuarios.GetUserChecked(id);
                var _Token = _userService.Authenticate(_User);
                
                //Declaracion de objetos
                EIResponseModel responseModel = new EIResponseModel();
                EIResponseUser responseUser = new EIResponseUser();

                if (_User != null)
                {
                    responseUser.usuario = _User;
                    responseUser.token = _Token;
                    responseModel.errorcodelayer = 0;
                    responseModel.statuscode = 200;
                    responseModel.errormsg = "Usuario encontrado con exito";
                    responseModel.success = true;
                }
                else
                {
                    responseModel.errorcodelayer = 1;
                    responseModel.statuscode = 404;
                    responseModel.errormsg = "No se ha podido encontrar al Usuario" + id.ToString();
                    responseModel.success = false;
                }
                responseUser.errores = responseModel;
                return responseUser;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
