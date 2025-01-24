using APICentral.Modelo;

namespace APICentral.Modelo
{
    public class ResponseListaApis
    {
        public List<APIs> apis { get; set; } = new List<APIs>();
        public ResponseModel errores { get; set; } = new ResponseModel();
    }
}
