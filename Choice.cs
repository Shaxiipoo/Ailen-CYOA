using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailen_CYOA
{
    internal class Choice
    {
        public Choice() 
        {

        }
        public string c_r_sDescription { get; set; }
        public Room c_r_cNextRoom { get; set; }
    }
}
