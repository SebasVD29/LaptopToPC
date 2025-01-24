using API1.Modelo;
using API1.Models;

namespace API1.IBLL
{
    public interface IUsuarioBLL
    {
        public Task<ResponseUsuario> Crear(Usuario usuario);
        public Task<ResponseUsuario> Actualizar(Usuario usuario);
        public Task<ResponseListaUsuario> Listar();
        public Task<ResponseUsuario> Obtener(int id);
    }
}
