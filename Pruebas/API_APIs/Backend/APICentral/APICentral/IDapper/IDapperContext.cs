using System.Data;

namespace APICentral.IDapper
{
    public interface IDapperContext
    {
        public IDbConnection CrearConexion();
    }
}
