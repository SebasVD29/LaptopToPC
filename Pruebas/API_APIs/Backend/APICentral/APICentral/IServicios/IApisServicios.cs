using APICentral.Modelo;
namespace APICentral.IServicios
{
    public interface IApisServicios
    {
        public Task<IEnumerable<APIs>> ListaAPIS();
    }
}
