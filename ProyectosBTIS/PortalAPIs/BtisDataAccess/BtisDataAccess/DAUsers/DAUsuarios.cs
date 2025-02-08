using BtisEntities.EUsers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtisDataAccess.DAUsers
{
    public class DAUsuarios
    {
        readonly DBConnection _DBConnection = new DBConnection();

        #region PublicMethods
        public EIUsers GetUser(int IdUsuario)
        {
            EIUsers _EIUsers = new EIUsers();

            using (SqlConnection _conn = new SqlConnection(_DBConnection.DBConnectionApis))
            {
                _conn.Open();

                using SqlCommand _cmd = new SqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "SP_";

                _cmd.Parameters.AddWithValue("@IdUsuario", Convert.ToString(IdUsuario));

                SqlDataReader DsReader = _cmd.ExecuteReader();

                if (DsReader.Read())
                {
                    _EIUsers = LoadUsers(DsReader);
                }
            }

            return _EIUsers;
        }
        #endregion

        #region PrivateMethods
        private EIUsers LoadUsers(IDataReader ReadyUsers)
        {
            return new EIUsers
            {
                IdUsuario = Convert.ToInt32(ReadyUsers["IdUsuario"]),
                NombreCompleto = Convert.ToString(ReadyUsers["NombreCompleto"]),
                CorreoElectronico = Convert.ToString(ReadyUsers["CorreoElectronico"]),
                Rol = Convert.ToString(ReadyUsers["Rol"]),
             
            };
        }

        #endregion

    }

}
