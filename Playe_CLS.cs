using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ailen_CYOA
{
    internal class Player
    {
        private string p_sName;
        public int p_iHealth { get; set; }
        public string[] p_asInventory { get; set; }
        public bool p_bHasbeentold { get; set; }
        //--------------------------------------------------------------
        //Constructor for player class
        public Player(string name, int inventorySize, int health)
        {
            p_sName = name;
            p_iHealth = health;
            p_asInventory = new string[inventorySize];
            p_bHasbeentold = false;
        }

        //--------------------------------------------------------------
        //Look to see if their is room in the players array inventory
        //if no room then return false
        public bool AddItemtoInventory(string item)
        {

            for (int i = 0; i < p_asInventory.Length; i++)
            {
                if (string.IsNullOrEmpty(p_asInventory[i]))
                {
                    p_asInventory[i] = item;

                    return true;
                }
            }
            return false;
        }

        //--------------------------------------------------------------
        //Display the inventory to the player, then repeat last loop
        public void f_DisplayInvetory()
        {
            bool hasAntthing = false;
            Console.WriteLine("---------------------------");
            Console.WriteLine("Inventory:");
            foreach(string item in p_asInventory)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Console.WriteLine(item);
                    hasAntthing = true;
                }
                else if(hasAntthing == false && p_bHasbeentold == false)
                {
                    p_bHasbeentold= true;
                    Console.WriteLine("Your pockets are empty");
                }
            }
            Console.WriteLine("---------------------------");

        }

        //------------------------------------------------------------
        //this is a temporary placeholder
        public string f_getname()
        {
            return p_sName;
        }

        //------------------------------------------------------------
        //player takes damage from the amount passed in as int
        public void f_takedamage(int damage)
        {
            if (damage > 0)
            {
                p_iHealth -= damage;
                if (p_iHealth < 0)
                {
                    p_iHealth = 0;
                }
            }
            return;
        }
        public int get_player_health(int health)
        {
            health = p_iHealth;
            return health;
        }
    }
}
