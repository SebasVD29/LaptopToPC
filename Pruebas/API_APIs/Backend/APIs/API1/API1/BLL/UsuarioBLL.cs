using API1.IBLL;
using API1.IServicios;
using API1.Modelo;
using API1.Models;

namespace API1.BLL
{
    public class UsuarioBLL : IUsuarioBLL
    {
        private readonly IUsuarioServicios _usuarioServicios;

        public UsuarioBLL(IUsuarioServicios usuarioServicios)
        {
            _usuarioServicios = usuarioServicios;
        }
        public async Task<ResponseUsuario> Crear(Usuario usuario)
        {
            try
            {
                var id = await _usuarioServicios.Crear(usuario);

                usuario.IdExternoUno = id;

                ResponseUsuario responseExternoUno = new ResponseUsuario();
                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = 0;
                responseModel.errormsg = "Usuario creado con éxito";

                responseExternoUno.usuario = usuario;
                responseExternoUno.errores = responseModel;
                return responseExternoUno;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<ResponseUsuario> Actualizar(Usuario usuario)
        {
            try
            {
                var rutaActualizado = await _usuarioServicios.Actualizar(usuario);
                ResponseUsuario responseRuta = new ResponseUsuario();
                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = 0;
                responseModel.errormsg = "Usuario Actualizado con éxito";

                responseRuta.usuario = rutaActualizado;
                responseRuta.errores = responseModel;
                return responseRuta;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<ResponseListaUsuario> Listar()
        {
            try
            {
                var listaUsuarios = await _usuarioServicios.Listar();

                ResponseListaUsuario responseLista = new ResponseListaUsuario();
                ResponseModel responseModel = new ResponseModel();

                responseLista.usuarios = listaUsuarios.ToList();
                responseModel.errorcode = 0;
                responseModel.errormsg = "Lista de Usuarios devuelta con éxito";

                responseLista.errores = responseModel;

                return responseLista;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ResponseUsuario> Obtener(int id)
        {
            try
            {
                var usuario = await _usuarioServicios.Obtener(id);

                ResponseUsuario responseUsuario = new ResponseUsuario();
                ResponseModel responseModel = new ResponseModel();


                if (usuario != null)
                {
                    responseUsuario.usuario = usuario;
                    responseModel.errorcode = 0;
                    responseModel.errormsg = "Usuario encontrado con éxito";

                }
                else
                {
                    responseModel.errorcode = 1;
                    responseModel.errormsg = "No se ha podido encontrar el Usuario con código: " + id.ToString();
                }

                responseUsuario.errores = responseModel;
                return responseUsuario;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
