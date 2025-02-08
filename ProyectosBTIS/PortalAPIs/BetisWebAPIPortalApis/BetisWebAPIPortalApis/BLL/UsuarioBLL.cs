using BtisDataAccess.DAUsers;
using BtisEntities.EUsers;

namespace BetisWebAPIPortalApis.BLL
{
    public class UsuarioBLL
    {

        private readonly DAUsuarios _DALogins = new DAUsuarios();
        public EIUsers GetUser(int id)
        {
            
            try
            {
                EIUsers eIUsers = new EIUsers();
                //Declaracion de objetos
                var _usuario = _DALogins.GetUser(id);
                //EIResponseUser eIResponseUser = new EIResponseUser();


                if (_usuario != null)
                {
                 
                    
                }
                else
                {
                    
                    //error
                }


                return ;
            }
            catch (Exception)
            {
                throw ;
            }
        }
    }
}
