using BtisEntities.ERoles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtisDataAccess.DARoles
{
    public class DARoles
    {
        readonly DBConnection _DBConnection = new DBConnection();

        #region PublicMethods
        public List<EIRol> Get_Roles()
        {
            try 
            {
                List<EIRol> _RolesList = new List<EIRol>();

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
                        _RolesList.Add(LoadRoles(DsReader));
                    }
                }

                return _RolesList;
            } 
            catch (Exception ex) 
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public EIRol Get_Rol_By_Name(string nombreRol)
        {
            try
            {
                EIRol _EIRol = new EIRol();
                using (SqlConnection _conn = new SqlConnection(_DBConnection.DBConnectionApis))
                {
                    _conn.Open();

                    using SqlCommand _cmd = new SqlCommand();
                    _cmd.Connection = _conn;
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.CommandText = "AP_";

                    _cmd.Parameters.AddWithValue("@NombreRol", Convert.ToString(nombreRol));
                    SqlDataReader DsReader = _cmd.ExecuteReader();

                    while (DsReader.Read())
                    {
                        _EIRol = LoadRoles(DsReader);
                    }
                }

                return _EIRol;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public int Insertar_Roles(EIRol _EIRol)
        {
            try
            {
                int IdRol;
                using SqlConnection _conn = new SqlConnection(_DBConnection.DBConnectionApis);
                _conn.Open();

                using SqlCommand _cmd = new SqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "AP_";

                _cmd.Parameters.AddRange(SetRoles(_EIRol));
                _cmd.Parameters["@IdRol"].Direction = ParameterDirection.Output;
                _cmd.ExecuteNonQuery();
                IdRol = Convert.ToInt32(_cmd.Parameters["@IdRol"].Value);
                return IdRol;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public bool Modificar_Roles(EIRol _EIRol)
        {
            try
            {
                bool Modifico;

                using SqlConnection _conn = new SqlConnection(_DBConnection.DBConnectionApis);
                _conn.Open();

                using SqlCommand _cmd = new SqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "AP_";
                _cmd.Parameters.AddRange(SetUpdateRoles(_EIRol));
                _cmd.Parameters["@Resultado"].Direction = ParameterDirection.Output;
                _cmd.ExecuteNonQuery();
                Modifico = Convert.ToBoolean(_cmd.Parameters["@Resultado"].Value);
                return Modifico;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public bool Eliminar_Roles(EIRol _EIRol)
        {

            try
            {
                bool Elimino;
                using SqlConnection _conn = new SqlConnection(_DBConnection.DBConnectionApis);
                _conn.Open();

                using SqlCommand _cmd = new SqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "AP_";
                _cmd.Parameters.AddRange(SetDeleteRol(_EIRol));
               
                _cmd.Parameters["@Resultado"].Direction = ParameterDirection.Output;
                _cmd.ExecuteNonQuery();
                Elimino = Convert.ToBoolean(_cmd.Parameters["@Resultado"].Value);

                return Elimino;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public EIRol Get_Roles_By_Id(int IdRol)
        {
            EIRol _EIRol = new EIRol();
            using (SqlConnection _conn = new SqlConnection(_DBConnection.DBConnectionApis))
            {
                _conn.Open();

                using SqlCommand _cmd = new SqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "AP_";
                _cmd.Parameters.AddWithValue("@IdRol", Convert.ToInt32(IdRol));
                //_cmd.Parameters.AddWithValue("@IdUsuario", Convert.ToString(IdUsuario));
                //_cmd.Parameters.AddWithValue("@IdCompania", Convert.ToString(IdCompania));

                SqlDataReader DsReader = _cmd.ExecuteReader();

                while (DsReader.Read())
                {
                    _EIRol = LoadRoles(DsReader);
                }
            }

            return _EIRol;
        }
        public bool Existe_Nombre_Rol(String NombreRol)
        {
            bool Existe;

            using (SqlConnection _conn = new SqlConnection(_DBConnection.DBConnectionApis))
            {
                _conn.Open();

                using SqlCommand _cmd = new SqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "AP_";

                _cmd.Parameters.AddWithValue("@NombreRol", Convert.ToString(NombreRol));
                _cmd.Parameters.Add("@Resultado", 0);
                _cmd.Parameters["@Resultado"].Direction = ParameterDirection.Output;
                _cmd.ExecuteNonQuery();
                Existe = Convert.ToBoolean(_cmd.Parameters["@Resultado"].Value);
            }

            return Existe;
        }
        #endregion

        #region PrivateMethods
        private EIRol LoadRoles(IDataReader ReadyRol)
        {
            return new EIRol
            {
               
                IdRol = Convert.ToInt32(ReadyRol["IdRol"]),
                NombreRol = Convert.ToString(ReadyRol["NombreRol"]),
                DescripcionRol = Convert.ToString(ReadyRol["DescripcionRol"]),
               

            };
        }
        private SqlParameter[] SetRoles(EIRol Roles)
        {
            return new SqlParameter[]
            {
               
                new SqlParameter ("@NombreRol",Convert.ToString(Roles.NombreRol)),
                new SqlParameter ("@DescripcionRol",Convert.ToString(Roles.DescripcionRol)),
                
            };
        }
        private SqlParameter[] SetUpdateRoles(EIRol Roles)
        {
            return new SqlParameter[]
            {

                new SqlParameter ("@NombreRol",Convert.ToString(Roles.NombreRol)),
                new SqlParameter ("@DescripcionRol",Convert.ToString(Roles.DescripcionRol)),
                new SqlParameter ("@Resultado", 0)

            };
        }
        private SqlParameter[] SetDeleteRol(EIRol Roles)
        {
            return new SqlParameter[]
            {
                new SqlParameter ("@IdRol",Convert.ToInt32(Roles.IdRol)),
                new SqlParameter ("@Resultado", 0)
            };
        }
        #endregion

    }
}
