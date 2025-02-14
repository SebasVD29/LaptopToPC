using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BtisEntities.ERoles;

namespace BtisDataAccess.DARoles
{
    public class DAAuditoriaRoles
    {
        readonly DBConnection _DBConnection = new DBConnection();
        #region PublicMethods
        public List<EIAuditoriaRol> Get_AuditoriaRol_All()
        {
            List<EIAuditoriaRol> _AuditoriaRolList = new List<EIAuditoriaRol>();

            using (SqlConnection _conn = new SqlConnection(_DBConnection.DBConnectionApis))
            {
                _conn.Open();

                using SqlCommand _cmd = new SqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "AP_";

                SqlDataReader DsReader = _cmd.ExecuteReader();

                while (DsReader.Read())
                {
                    _AuditoriaRolList.Add(LoadAuditoriaRoles(DsReader));
                }
            }

            return _AuditoriaRolList;
        }
        public int Insert_AuditoriaRol(EIAuditoriaRol _EIAuditoriaRol)
        {
            int _IdAuditoria;
            try
            {
                using SqlConnection _conn = new SqlConnection(_DBConnection.DBConnectionApis);
                _conn.Open();

                using SqlCommand _cmd = new SqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "AP_";

                _cmd.Parameters.AddRange(SetAuditoriaRoles(_EIAuditoriaRol));
                _cmd.Parameters["@_IdAuditoria"].Direction = ParameterDirection.Output;
                _cmd.ExecuteNonQuery();
                _IdAuditoria = Convert.ToInt32(_cmd.Parameters["@IdAuditoriaRol"].Value);
                return _IdAuditoria;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion

        #region PrivateMethods
        private EIAuditoriaRol LoadAuditoriaRoles(IDataReader ReadyRol)
        {
            return new EIAuditoriaRol
            {
                IdAuditoriaRol = Convert.ToInt32(ReadyRol["IdAuditoriaRol"]),
                IdRol = Convert.ToInt32(ReadyRol["IdRol"]),
                CorreoUsuario = Convert.ToString(ReadyRol["CorreoUsuario"]),
                NombreUsuario = Convert.ToString(ReadyRol["NombreUsuario"]),
                Accion = Convert.ToString(ReadyRol["Accion"]),
                FechaAccion = Convert.ToDateTime(ReadyRol["IdUsuario"])

            };
        }
        private SqlParameter[] SetAuditoriaRoles(EIAuditoriaRol AuditoriaRoles)
        {
            return new SqlParameter[]
            {
                new SqlParameter ("@IdRol",Convert.ToInt32(AuditoriaRoles.IdRol)),
                new SqlParameter ("@CorreoUsuario",Convert.ToString(AuditoriaRoles.CorreoUsuario)),
                new SqlParameter ("@NombreUsuario",Convert.ToString(AuditoriaRoles.NombreUsuario)),
                new SqlParameter ("@Accion",Convert.ToString(AuditoriaRoles.Accion)),
                new SqlParameter ("@Accion",Convert.ToDateTime(AuditoriaRoles.FechaAccion))
            };
        }
        #endregion
    }
}
