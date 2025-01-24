using API1.Modelo;
namespace API1.Models
{
    public class ResponseUsuario
    {
        public Usuario usuario { get; set; } = new Usuario();
        public ResponseModel errores { get; set; } = new ResponseModel();  
    }
}
