using API1.IBLL;
using API1.Modelo;
using API1.Models;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBLL _usuarioBLL;
        public UsuarioController(IUsuarioBLL usuarioBLL)
        {
            _usuarioBLL = usuarioBLL;
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public async Task<ActionResult<ResponseUsuario>> Crear(Usuario usuario)
        {
            try
            {
                var response = await _usuarioBLL.Crear(usuario);
                return new JsonResult(response);
            }
            catch (Exception)
            {
                ResponseUsuario responseExternoUno = new ResponseUsuario();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al insertar el ExternoUno";
                responseExternoUno.errores = responseModel;
                return new JsonResult(responseExternoUno);
            }
        }

        [AcceptVerbs("POST", "PUT")]
        [Route("ActualizarUsuario")]
        public async Task<ActionResult<ResponseUsuario>> Actualizar(Usuario usuario)
        {
            try
            {

                var response = await _usuarioBLL.Actualizar(usuario);
                return new JsonResult(response);
            }
            catch (Exception)
            {

                ResponseUsuario responseUsuario = new ResponseUsuario();
                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al actulizar al Usuario";
                responseUsuario.errores = responseModel;
                return new JsonResult(responseUsuario);
            }
        }

        [HttpGet]
        [Route("ListarUsuario")]
        public async Task<ActionResult<ResponseListaUsuario>> Listar()
        {
            try
            {
                return await _usuarioBLL.Listar();
            }
            catch (Exception)
            {

                ResponseListaUsuario responseUsuarios = new ResponseListaUsuario();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al obtener la lista de usuarios";
                responseUsuarios.errores = responseModel;
                return responseUsuarios;



            }
        }

        [HttpGet]
        [Route("ObtenerUsuario")]
        public async Task<ActionResult<ResponseUsuario>> ObtenerCliente(int id)
        {
            try
            {
                return await _usuarioBLL.Obtener(id);

            }
            catch (Exception)
            {

                ResponseUsuario responseUsuario = new ResponseUsuario();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al Obtner el Usuario";
                responseUsuario.errores = responseModel;
                return new JsonResult(responseUsuario);
            }
        }

    }
}

