using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ailen_CYOA
{
    internal class Room
    {
        public string r_sDescription { get; set; }
        public List<Choice> r_lChoices { get; set; }
        public List<Enemy_CLS> r_lEnemies;
        //public Room nextroom { get; set; }
        
        public Room()
        {
            r_lChoices = new List<Choice>();
            r_lEnemies = new List<Enemy_CLS>();
        }
    }
}
