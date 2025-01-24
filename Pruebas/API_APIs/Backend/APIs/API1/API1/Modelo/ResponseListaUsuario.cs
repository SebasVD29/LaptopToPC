using API1.Modelo;

namespace API1.Modelo
{
    public class ResponseListaUsuario
    {
        public List<Usuario> usuarios { get; set; } = new List<Usuario>();
        public ResponseModel errores { get; set; } = new ResponseModel();
    }
}

