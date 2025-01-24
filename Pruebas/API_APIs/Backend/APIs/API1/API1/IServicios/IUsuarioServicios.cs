using API1.Modelo;
namespace API1.IServicios
{
    public interface IUsuarioServicios
    {
        public Task<int> Crear(Usuario usuario);
        public Task<Usuario> Actualizar(Usuario usuario);
        public Task<IEnumerable<Usuario>> Listar();
        public Task<Usuario> Obtener(int id);
    }
}
