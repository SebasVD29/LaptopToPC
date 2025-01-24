using APICentral.Modelo;

namespace APICentral.IBLL
{
    public interface IApisBLL
    {
        public Task<ResponseListaApis> ListaAPIS();
    }
}
