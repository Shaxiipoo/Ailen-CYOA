using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailen_CYOA
{
    public class basic_enemy_cld : Enemy_CLS
    {
        int basic_enemy_state = 0;
        public basic_enemy_cld(string a_itemdropped, int health, int attack, float def)
        {
            pt_sItemdropped = a_itemdropped;
            pt_iHealth = health;
            pt_iAttack = attack;
            pt_iDefense = def;
            basic_enemy_state++;
        }
        public override float get_defence(float def)
        {
            def = def * pt_iDefense;
            return def;
        }
        public override int take_dmg(int amount)
        {
            pt_iHealth -= amount;
            return pt_iHealth;
        }
    }
}
