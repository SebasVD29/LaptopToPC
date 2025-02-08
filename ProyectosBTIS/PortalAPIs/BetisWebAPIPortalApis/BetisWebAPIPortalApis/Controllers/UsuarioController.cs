using BetisWebAPIPortalApis.BLL;
using BetisWebAPIPortalApis.Services;
using BtisEntities.EUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetisWebAPIPortalApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        private readonly UsuarioBLL _usuarioBLL;
        public UsuarioController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
            
        }

        [HttpPost("GetUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser(int id)
        {

            try
            {
                return _usuarioBLL.GetUser(id);
            }
            catch (Exception)
            {
                //cambiar
                return new JsonResult(null);
            }
            
        }
    }
}
