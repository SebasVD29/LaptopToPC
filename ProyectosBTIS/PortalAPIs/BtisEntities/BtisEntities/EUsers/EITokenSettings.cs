using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtisEntities.EUsers
{
    public class EITokenSettings
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
        public string Audience { get; set; }
    }
}
