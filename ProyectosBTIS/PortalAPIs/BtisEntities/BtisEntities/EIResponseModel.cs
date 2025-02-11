using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtisEntities
{
    public class EIResponseModel
    {
        public int errorcodelayer {  get; set; }
        public int statuscode {  get; set; }
        public string errormsg { get; set; }
        public bool success { get; set; }
    }
}
