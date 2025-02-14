using BtisDataAccess.DARoles;
using BtisDataAccess.DAUsers;
using BtisEntities.ERoles;


namespace BetisWebAPIPortalApis.BLL
{
    public class RolBLL
    {
        private readonly DARoles _DARoles = new DARoles();
        private readonly DAUsuarios _DAUsuarios = new DAUsuarios();
        private readonly AuditoriaRolBLL _AuditoriaRolBLL = new AuditoriaRolBLL();

        public int Create_Rol(EIAuditoriaRol _EIAuditoriaRol)
        {
            try
            {
                int Rol;

                EIRol _EIRol = new EIRol();
                _EIRol.NombreRol = _EIAuditoriaRol.NombreRol;
                _EIRol.DescripcionRol = _EIAuditoriaRol.DescripcionRol;

                //Verificar si el nombre del rol ya existe
                if (_DARoles.Existe_Nombre_Rol(_EIRol.NombreRol))
                {
                    return 0;
                }
                else
                {
                    Rol =_DARoles.Insertar_Roles(_EIRol);
                }

                if(Rol > 0)
                {
                    _AuditoriaRolBLL.RegistrarAuditoriaRol(_EIAuditoriaRol);
                    return Rol;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool Modificar_Roles(EIAuditoriaRol _EIAuditoriaRol)
        {
            try
            {
                bool Modifico;
                EIRol _EIRol = new EIRol();
                _EIRol.IdRol = (int)_EIAuditoriaRol.IdRol;
                _EIRol.NombreRol = _EIAuditoriaRol.NombreRol;
                _EIRol.DescripcionRol = _EIAuditoriaRol.DescripcionRol;

                if (_AuditoriaRolBLL.RegistrarAuditoriaRol(_EIAuditoriaRol) > 0)
                {
                    Modifico = _DARoles.Modificar_Roles(_EIRol); 
                }
                else
                {
                    Modifico = false;
                }
                
                return Modifico;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool Eliminar_Roles(EIAuditoriaRol _EIAuditoriaRol)
        {
            try
            {
                bool Elimino;

                EIRol _EIRol = new EIRol();
                _EIRol.IdRol = (int)_EIAuditoriaRol.IdRol;
                _EIRol.NombreRol = _EIAuditoriaRol.NombreRol;
                _EIRol.DescripcionRol = _EIAuditoriaRol.DescripcionRol;
                //Verificar si el rol existe en algun usuario
                if (!_DAUsuarios.Exist_Rol_In_User(_EIRol.NombreRol))
                {
                    if (_AuditoriaRolBLL.RegistrarAuditoriaRol(_EIAuditoriaRol) > 0)
                    {
                        Elimino = _DARoles.Eliminar_Roles(_EIRol); ; 
                    }
                    else
                    {
                        Elimino = false;
                    }
                }
                else
                {
                    Elimino = false;
                }

                return Elimino;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
