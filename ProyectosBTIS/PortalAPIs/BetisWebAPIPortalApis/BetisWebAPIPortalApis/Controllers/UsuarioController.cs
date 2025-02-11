using BetisWebAPIPortalApis.BLL;
using BetisWebAPIPortalApis.Services;
using BtisEntities;
using BtisEntities.EUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BetisWebAPIPortalApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        private readonly UsuarioBLL _usuarioBLL;
        private readonly ResponseMessage Mensaje = new ResponseMessage();
        public UsuarioController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
            
        }

        [HttpPost("GetAccessUser")]
        [AllowAnonymous]
        public IActionResult GetAccessUser([FromBody] EIUsers Users)
        {
            try
            {
                int idUsuario = _usuarioBLL.GetIdUserCorreo(Users.CorreoElectronico);
                if (idUsuario == 0)
                {
                    return Mensaje.Credenciales_Incorrectas();
                }
                else
                {
                    EIResponseUser _EIResponseUser = _usuarioBLL.GetUsersId(Convert.ToInt32(idUsuario));
                    return new JsonResult(_EIResponseUser);

                }

            }
            catch (Exception ex)
            {
                EIResponseModel responseModel = new EIResponseModel();
                EIResponseUser responseUser = new EIResponseUser();

                responseModel.errorcodelayer = -1;
                responseModel.success = false;
                responseModel.statuscode = 404;
                responseModel.errormsg = ex.Message;
                responseUser.errores = responseModel;

                return new JsonResult(responseUser);
            }
        }
    }

}


//UsuarioExterno _IdUsuario = new UsuarioExterno();
//_IdUsuario = _BLUsers.InfoUsuario(Users.CorreoElectronico);

//if (_IdUsuario.IdUsuario == 0)
//{
//    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = "Usuario no existe en el sistema", success = false }));
//}
//else
//{
//    ResponseUser _EIResponseUser = new ResponseUser();

//    var usuario = _BLUsers.GetUsersId(Convert.ToInt32(_IdUsuario.IdUsuario), _IdUsuario.Externo);
//    _EIResponseUser.IdIdiomaDefault = "es";
//    _EIResponseUser.IdTemaCssDefault = "theme-default";
//    _EIResponseUser.Nombre = usuario.Nombre;
//    _EIResponseUser.Correo = Users.CorreoElectronico;
//    _EIResponseUser.IdCliente = usuario.IdCliente;
//    _EIResponseUser.Telefono = usuario.Telefono;
//    _EIResponseUser.Token = _userService.Authenticate(Users);
//    _EIResponseUser.IdUsuario = Convert.ToInt32(_IdUsuario.IdUsuario);
//    _EIResponseUser.Externo = Convert.ToInt32(_IdUsuario.Externo);
//    _EIResponseUser.Roles = Convert.ToString(usuario.Roles);
//    _EIResponseUser.NumeroEmpleado = Convert.ToString(usuario.NumeroEmpleado);
//    _EIResponseUser.Cedula = Convert.ToString(usuario.Cedula);
//    _EIResponseUser.UsuarioPrueba = _config.GetValue<string>("ApplicationSettings:UsuarioHernan");
//    return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(new { msg = _EIResponseUser, success = true }));
//}
