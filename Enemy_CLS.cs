using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ailen_CYOA
{
    public abstract class Enemy_CLS
    {
        protected int pt_iHealth;
        protected int pt_iAttack;
        protected float pt_iDefense;
        static string youkilled;
        public static int enemies_killed = 0;
     
        protected string pt_sItemdropped;
        public Enemy_CLS()
        {
            pt_iHealth = 2;
            pt_iAttack = 2;
            pt_iDefense = 0.5f;
            youkilled = "You killed the enemy, and moved into the next room";
    }
        public int get_health(int hlth)
        {
            hlth = pt_iHealth;
            return hlth;
        }
        public int get_attack(int atk)
        {
            return pt_iAttack;
        }

        public virtual float get_defence(float def)
        {
            def = def * pt_iDefense;
            return def;
        }

        public virtual int take_dmg(int amount)
        {
            pt_iHealth -= amount;
            return pt_iHealth;
        }

        public string get_item()
        {
            return pt_sItemdropped;
        }

        public static string get_who_you_killed()
        {
            return youkilled;
        }
    }
}
