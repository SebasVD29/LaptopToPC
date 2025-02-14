using BtisDataAccess.DARoles;
using BtisDataAccess.DAUsers;
using BtisEntities.ERoles;

namespace BetisWebAPIPortalApis.BLL
{
    public class AuditoriaRolBLL
    {
        private readonly DAAuditoriaRoles _DAAuditoriaRol = new DAAuditoriaRoles();
        private readonly DARoles _DARoles = new DARoles();
        private readonly DAUsuarios _DAUsuarios = new DAUsuarios();

        public EIResponseListaAuditoriaRol GetAllAuditoriaRoles()
        {
            try
            {
                var _AuditoriaRoles = _DAAuditoriaRol.Get_AuditoriaRol_All();

                EIResponseListaAuditoriaRol responseListaAuditoriaRol = new EIResponseListaAuditoriaRol();
                responseListaAuditoriaRol.auditoriaRolLista = _AuditoriaRoles;

                return responseListaAuditoriaRol;
            }
            catch (Exception ex)
            {
                throw ;
            }
        }
        public int RegistrarAuditoriaRol(EIAuditoriaRol _EIAuditoriaRol)
        {
            try
            {
                int Auditoria;
                var _User = _DAUsuarios.Get_User_Checked(_EIAuditoriaRol.CorreoUsuario);
                var _Rol = _DARoles.Get_Rol_By_Name(_EIAuditoriaRol.NombreRol);
                if (_User.IdUsuario <= 0 && _Rol.IdRol <= 0)
                {
                    //ERROR El usuario no existe para crear la auditoria del rol
                    return 0;
                }
                else
                {
                    _EIAuditoriaRol.NombreUsuario = _User.NombreUsuario;
                    _EIAuditoriaRol.IdRol = _Rol.IdRol;
                }

                Auditoria = _DAAuditoriaRol.Insert_AuditoriaRol(_EIAuditoriaRol);
                return Auditoria;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
          
        }

    }
}
