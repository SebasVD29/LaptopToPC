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
        //private readonly IUserService _userService;
        private readonly UsuarioBLL _usuarioBLL;
        private readonly ResponseMessage Mensaje = new ResponseMessage();
        public UsuarioController(IConfiguration config, /*IUserService userService,*/ UsuarioBLL usuarioBLL)
        {
            _config = config;
            //_userService = userService;
            _usuarioBLL = usuarioBLL;


        }


        [HttpGet("GetAccessUser")]
        [AllowAnonymous]
        public IActionResult GetAccessUser(string correo)
        {
            try
            {
                EIResponseUser _EIResponseUser = _usuarioBLL.GetUsersChecked(correo);

                if (_EIResponseUser.usuario.IdUsuario > 0)
                {
                    return Mensaje.OK_EIuser(_EIResponseUser);
                }
                else
                {
                    return Mensaje.Credenciales_Incorrectas();
                }
            }
            catch (Exception ex)
            {
                return Mensaje.Credenciales_Incorrectas();
            }
        }
    }

}



