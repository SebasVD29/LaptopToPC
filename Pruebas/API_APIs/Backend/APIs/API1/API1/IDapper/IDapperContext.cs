using System.Data;

namespace API1.IDapper
{
    public interface IDapperContext
    {
        public IDbConnection CrearConexion();
    }
}
