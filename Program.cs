using System.ComponentModel.Design;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Ailen_CYOA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Onstart
            Console.WriteLine("Enter your players name");
            string m_sPlayername = Console.ReadLine();
            int m_iInventorySize = 10;
            Player m_cPlayer = new Player(m_sPlayername, m_iInventorySize, 5);
            Room empty = new Room()
            {
                r_sDescription = "this room is empty"
            };

            //----------------------------------------------------------
            //constant strings used to find item adding, attacking etc  
            const string attack_enim = "You attack the enemy";
            const string look_pock = "Look through your pocekts";
            const string pick_orb = "Pick up an orb & run";
            const string pick_knife = "You grab a knife & run";
            const string pick_katana = "You pick up a katana!";
            const string pick_spoon = "You pick up a....spoon?";
            const string unlock_door = "You try to unlock the door";
            const string try_escape = "You try to escape";
            const string defy_narrator = "You try to give the aliens a big fat hug";
            const string key = "Key";
            const string map = "Map";
            const string Orb = "Orb";
            const string knife = "Knife";
            const string katana = "Katana";
            const string spoon = "Spoon";
            //----------------------------------------------------------

            Room bruh = new Room()
            {
                r_sDescription = "Dude........why?",
                r_lChoices = new List<Choice>
                {
                    new Choice() {c_r_sDescription = defy_narrator, c_r_cNextRoom = null},
                }
            };

            Room esacpeRoom = new Room()
            {
                r_sDescription = "You enter a room with numerous escape pods, what do you do?",
                r_lChoices = new List<Choice>
                {
                    new Choice() {c_r_sDescription = "Jump in the escape pod?", c_r_cNextRoom = null},
                    new Choice() {c_r_sDescription = "Defy the narrator and go back to become one with the aliens", c_r_cNextRoom = bruh},
                    new Choice() {c_r_sDescription = look_pock, c_r_cNextRoom = empty}
                }
            };

            Room largedoor = new Room()
            {
                r_sDescription = "You enter an empty room with a large door infront of you",
                r_lChoices = new List<Choice>
                {
                    new Choice() {c_r_sDescription = unlock_door,c_r_cNextRoom = esacpeRoom},
                    new Choice() {c_r_sDescription = look_pock, c_r_cNextRoom = empty}
                }

            };

            Room death = new Room()
            {
                r_sDescription = "A group of aliens appears infront of you. Your trapped!",
                r_lChoices = new List<Choice>
                {
                    new Choice() {c_r_sDescription = try_escape, c_r_cNextRoom = empty},
                }
            };

            Room choiceoflife = new Room()
            {
                r_sDescription = "You enter a room with a door on your left, and a door on your right. If only you had a map! Which way do you go?",
                r_lChoices = new List<Choice>
                {
                    new Choice() {c_r_sDescription = "Run twards the door on the left", c_r_cNextRoom = death},
                    new Choice() {c_r_sDescription = "Run twards the door on the right", c_r_cNextRoom = largedoor},
                    new Choice() {c_r_sDescription = look_pock, c_r_cNextRoom = empty}
                }
            };

            Room engineering = new Room
            {
                r_sDescription = "Your enter a room filled with technology, you see a door on your right, and a enemy on your left",
                r_lChoices = new List<Choice>
                {
                    new Choice() {c_r_sDescription = attack_enim, c_r_cNextRoom = choiceoflife},
                    new Choice() {c_r_sDescription = "Run for the door on the right", c_r_cNextRoom = choiceoflife},
                    new Choice() {c_r_sDescription = look_pock, c_r_cNextRoom = empty},
                },
                r_lEnemies = new List<Enemy_CLS>
                {
                    new second_enemy_cld(map,1,1,1)
                }
            };
            
            second_enemy_cld secondEnemy = (second_enemy_cld)engineering.r_lEnemies[0];
            //purpose for being a dirrived class is so that they may drop different items to the players inventory.
            Room RoomfullofEnemies = new Room
            {
                r_sDescription = "You stumble across a room with an enemey holding a key! You cant run past them! What do you do!",
                r_lChoices = new List<Choice>
                {
                    new Choice { c_r_sDescription = attack_enim, c_r_cNextRoom = engineering },
                    new Choice { c_r_sDescription = look_pock, c_r_cNextRoom = empty },
                },
                r_lEnemies = new List<Enemy_CLS>
                {
                    new basic_enemy_cld(key, 1, 1,1)
                }
            };

            basic_enemy_cld firstEnemy = (basic_enemy_cld)RoomfullofEnemies.r_lEnemies[0];

            Room artifactroom = new Room
            {
                r_sDescription = "You find a room full of alien artifacts. There is a door ahead of you but you can't see what lies beyond",
                r_lChoices = new List<Choice>
                {
                    new Choice {c_r_sDescription = pick_orb, c_r_cNextRoom = RoomfullofEnemies},
                    new Choice {c_r_sDescription = pick_knife, c_r_cNextRoom = RoomfullofEnemies},
                    new Choice {c_r_sDescription = pick_katana, c_r_cNextRoom = RoomfullofEnemies},
                    new Choice {c_r_sDescription = pick_spoon, c_r_cNextRoom = RoomfullofEnemies},
                    new Choice {c_r_sDescription = look_pock, c_r_cNextRoom = empty},
                }
            };

            Room airDuct = new Room
            {
                r_sDescription = "You continue to escape! You see a air duct and climb inside! You crawl past a room with an emeny holding a key.",
                r_lChoices = new List<Choice>
                {
                    new Choice {c_r_sDescription = "Drop out into the room with an enemy in it? ", c_r_cNextRoom = RoomfullofEnemies},
                    new Choice {c_r_sDescription = "Queitly keep crawling", c_r_cNextRoom = choiceoflife},
                    new Choice {c_r_sDescription = look_pock, c_r_cNextRoom = empty},
                }
            };

            Room largeRoom = new Room
            {
                r_sDescription = "You enter a large room with 4 doors",
                r_lChoices = new List<Choice>
                {
                    new Choice {c_r_sDescription = "Go left twards a artifact room", c_r_cNextRoom = artifactroom},
                    new Choice {c_r_sDescription = "Go right and climb in an airduct", c_r_cNextRoom = airDuct},
                    new Choice {c_r_sDescription = look_pock, c_r_cNextRoom = empty},
                }

            };

            Room darkHallway = new Room
            {
                r_sDescription = $"You move into a dark hallway",
                r_lChoices = new List<Choice>
                {
                    new Choice {c_r_sDescription = "Go left down the hallway twards a large room?", c_r_cNextRoom = largeRoom},
                    new Choice {c_r_sDescription = "Go right down the hallway twards an airduct?", c_r_cNextRoom =airDuct},
                    new Choice {c_r_sDescription = look_pock, c_r_cNextRoom = empty},


                }
            };

            Room startingroom = new Room
            {
                r_sDescription = $"Hello {m_sPlayername}, you wake up atop a medical chair.You see a dark hallway to your left, and a door to a large room to on your right. Which way do you go?",
                r_lChoices = new List<Choice>
                {
                    new Choice() {c_r_sDescription = "Go left twards a large room", c_r_cNextRoom = largeRoom},
                    new Choice() {c_r_sDescription = "Go right twards a dark hallway", c_r_cNextRoom = darkHallway},
                    new Choice() {c_r_sDescription = look_pock, c_r_cNextRoom = empty},
                }
            };

            Room currentRoom = startingroom;

            //Game conditional state: This is broken by declaring the room as null. If room is null the while loop is exited, stopping the prompt for linked list traversal (.next)
            while (currentRoom != null && m_cPlayer.p_iHealth > 0)
            {
                Console.WriteLine(currentRoom.r_sDescription);
                DisplayChoices(currentRoom.r_lChoices);

                int choiceIndex = GetChoiceIndex(currentRoom, currentRoom.r_lChoices.Count);

                if (choiceIndex != -1)
                {
                    Enemy_CLS roomEnemy = null;
                    if (currentRoom.r_lEnemies != null && currentRoom.r_lEnemies.Count > 0)
                    {
                        roomEnemy = currentRoom.r_lEnemies[0];
                    }
                    HandleChoice(currentRoom, choiceIndex, m_cPlayer, roomEnemy, empty);

                    // After handling the choice, update the current room
                    if (choiceIndex >= 0 && choiceIndex < currentRoom.r_lChoices.Count)
                    {
                        if (currentRoom.r_lChoices[choiceIndex].c_r_cNextRoom != empty)
                        {
                            currentRoom = currentRoom.r_lChoices[choiceIndex].c_r_cNextRoom;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Choice, please try again.");
                }
                //If the players health goes down to 0 then exit the conditional state for the while loop
                if (m_cPlayer.p_iHealth <= 0)
                {
                    Console.WriteLine("Game over!");
                    //currentRoom = null;
                    return;
                }
                if (currentRoom == null)
                {
                    Console.WriteLine("You enter an escape pod and jump in flying down back to earth. Congrats, you escaped!");
                    Console.WriteLine("You killed " + Enemy_CLS.enemies_killed + " enemies");
                    //..................................
                    //currentRoom = null;
                }

            }
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++           
            //Handles displaying the choices that are too be displayeed depending on the rooms list of choices
            static void DisplayChoices(List<Choice> choices)
            {
                Console.WriteLine("Choose an option:");
                for (int i = 0; i < choices.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {choices[i].c_r_sDescription}");
                }
            }
            //-----------------------------------------------------------------------------
                     
            //Handles what to do WITH said choice (beginng of branch logic
            static void HandleChoice(Room currentRoom, int choiceIndex, Player c_player, Enemy_CLS firstEnemy, Room empty)
            {
                Choice chosenChoice = currentRoom.r_lChoices[choiceIndex];
                string choiceDescription = chosenChoice.c_r_sDescription;

                if (choiceDescription == attack_enim)
                {
                    HandleAttack(currentRoom, c_player, firstEnemy, choiceIndex, empty);
                }
                //player picks orb
                else if (choiceDescription == pick_orb)
                {
                    HandlePickup(currentRoom, Orb, c_player, choiceIndex);
                }
                //player picks knife
                else if (choiceDescription == pick_knife)
                {
                    HandlePickup(currentRoom, knife, c_player, choiceIndex);
                }
                //player picks katana
                else if (choiceDescription == pick_katana)
                {
                    HandlePickup(currentRoom, katana, c_player, choiceIndex);
                }
                //player chooses spoon????
                else if (choiceDescription == pick_spoon)
                {
                    HandlePickup(currentRoom, spoon, c_player, choiceIndex);
                }
                //player decided to look through their pockets
                else if (choiceDescription == look_pock)
                {
                    c_player.f_DisplayInvetory();
                    c_player.p_bHasbeentold = false;
                    if (c_player.p_asInventory.Contains(map) && currentRoom.r_sDescription == "You enter a room with a door on your left, and a door on your right. If only you had a map! Which way do you go?")
                    {
                        Console.WriteLine("You look at the map, which shows the following: ");
                        Console.WriteLine("     X -------------| ----------->");
                    }
                }

                else if (choiceDescription == try_escape || choiceDescription == defy_narrator)
                {
                    Console.WriteLine("You try to resist but you are overwhelmed and killed in the process!");
                    c_player.p_iHealth = 0;
                }

                else if (choiceDescription == unlock_door)
                {
                    if (c_player.p_asInventory.Contains(key))
                    { 
                        Console.WriteLine("You unlock the door with the key you got from the first enemy you killed!");
                    }
                    else
                    {
                        Console.WriteLine("You try to fidget with the door but its hopeless, you can't get through. You go back to the previous room and end up getting caught and disected!");
                        c_player.p_iHealth = 0;
                    }
                }
                else
                {

                }    
            }

            //-----------------------------------------------------------------------------
            //Handles if the player picks something up, or is given something from an enemy
            static void HandlePickup(Room currentRoom, string item, Player c_player, int choiceIndex)
            {
                //Pick up a knife
                if (currentRoom.r_lChoices[choiceIndex].c_r_sDescription == pick_knife)
                {
                    string newItem = knife;
                    bool added = c_player.AddItemtoInventory(newItem);
                    if (added)
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"You picked up a [{newItem}]");
                        Console.WriteLine("----------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("You don't have any room in your pockets.");
                    }
                }

                //------------------------------------------------------------------
                //Pick up orb player choice
                if (currentRoom.r_lChoices[choiceIndex].c_r_sDescription == pick_orb)
                {
                    string newItem = Orb;
                    bool added = c_player.AddItemtoInventory(newItem);
                    if (added)
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"You picked up a [{newItem}]");
                        Console.WriteLine("----------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("You don't have any room in your pockets.");
                    }
                }
                //-------------------------------------------------------------------
                if (currentRoom.r_lChoices[choiceIndex].c_r_sDescription == pick_katana)
                {
                    string newItem = katana;
                    bool added = c_player.AddItemtoInventory(newItem);
                    if (added)
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"You picked up a [{newItem}]");
                        Console.WriteLine("----------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("You don't have any room in your pockets.");
                    }
                }
                if (currentRoom.r_lChoices[choiceIndex].c_r_sDescription == pick_spoon)
                {
                    string newItem = spoon;
                    bool added = c_player.AddItemtoInventory(newItem);
                    if (added)
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"You picked up a [{newItem}]");
                        Console.WriteLine("----------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("You don't have any room in your pockets.");
                    }
                }
            }

            //-----------------------------------------------------------------------------
            //Handles if the player chose to attack

            static void HandleAttack(Room currentRoom, Player c_player, Enemy_CLS Enemy, int choiceIndex, Room empty)
            {
                if (currentRoom.r_lEnemies.Count > 0 && c_player.p_asInventory.Contains(Orb))
                {
                    currentRoom = orb_attack(currentRoom, c_player, Enemy, choiceIndex, empty);
                }
                else if (currentRoom.r_lEnemies.Count > 0 && c_player.p_asInventory.Contains(knife))
                {
                    currentRoom = knife_attack(currentRoom, c_player, Enemy, choiceIndex, empty);
                }
                else if (currentRoom.r_lEnemies.Count > 0 && c_player.p_asInventory.Contains(katana))
                {
                    currentRoom = katana_attack(currentRoom, c_player, Enemy, choiceIndex, empty);
                }
                else if (currentRoom.r_lEnemies.Count > 0 && c_player.p_asInventory.Contains(spoon))
                {
                    currentRoom = spoon_attack(currentRoom, c_player, Enemy, choiceIndex, empty);
                }
                else if (currentRoom.r_lEnemies.Count > 0 && c_player.p_asInventory.Contains(null))
                {
                    Console.WriteLine("You have nothing to attack with");
                    c_player.p_iHealth = 0;
                }
                else
                {

                }
            }

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //-----------------------------------------------------------
            //defines what to do if the player has an orb for the attack
            static Room orb_attack(Room currentRoom, Player c_player, Enemy_CLS Enemy, int choiceIndex, Room empty)
            {
                //make the enemy take damage FIRST, and spesifcy the amount
                currentRoom.r_lEnemies[0].take_dmg(1);
                //then check if the enemy dies
                
                if (currentRoom.r_lEnemies[0].get_health(1) <= 0)
                {
                    //cool they did
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    Console.WriteLine("The enemy stares at the super shiny orb in your pocket, you take it our and the enenmy T-poses.");
                    Console.WriteLine("You here a strange voice wisper 'Going to need to fix that bug'");
                    Console.WriteLine(Enemy_CLS.get_who_you_killed()); //using static varible
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    string a_itemdropped = currentRoom.r_lEnemies[0].get_item();
                    Enemy_CLS.enemies_killed++;
                    bool added = c_player.AddItemtoInventory(a_itemdropped);
                    if (added)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine($"You picked up a [{a_itemdropped}]");
                        Console.WriteLine("----------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("You don't have any room in your pockets.");
                        Console.WriteLine("----------------------------------------------");
                    }
                    //remove the enemy from the Enemy.List in the currentRoom
                }
                else
                {

                }
                if (currentRoom.r_lChoices[choiceIndex].c_r_cNextRoom != empty && currentRoom.r_lEnemies.Count > 0) //go to the next room, as specified in the nextRoom of that choice in the choiceIndex of the currentRoom
                {
                    currentRoom.r_lEnemies.RemoveAt(0);
                }
                return currentRoom;
            }

            //-----------------------------------------------------------
            //defines what to do if the player has a knife for the attack
            static Room knife_attack(Room currentRoom, Player c_player, Enemy_CLS Enemy, int choiceIndex, Room empty)
            {
                //If they do have it in their inventory, make the enemy take damage
                currentRoom.r_lEnemies[0].take_dmg(1);

                if (currentRoom.r_lEnemies[0].get_health(1) <= 0)
                {
                    //Enemy dies from the attack
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    Console.WriteLine("You rush the enemy and throw the knife with all the grace of a small kangaroo");
                    Console.WriteLine("The knife cuts the enemy entirely inhalf, defying every single law of physics, causing you to have a mid-life crisis right there and then");
                    Console.WriteLine(Enemy_CLS.get_who_you_killed()); //using static varible
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    string a_itemdropped = currentRoom.r_lEnemies[0].get_item();
                    Enemy_CLS.enemies_killed++;
                    bool added = c_player.AddItemtoInventory(a_itemdropped);
                    if (added)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine($"You picked up a {a_itemdropped}");
                        Console.WriteLine("----------------------------------------------");

                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------------");

                        Console.WriteLine("You don't have any room in your pockets.");
                    }
                }
                else
                {
                    
                }
                if (currentRoom.r_lChoices[choiceIndex].c_r_cNextRoom != empty && currentRoom.r_lEnemies.Count > 0) //go to the next room, as specified in the nextRoom of that choice in the choiceIndex of the currentRoom
                {
                    currentRoom.r_lEnemies.RemoveAt(0);
                }
                return currentRoom;
            }

            //----------------------------------------------------------
            //definds what to do if the player has a katana for the attack
            static Room katana_attack(Room currentRoom, Player c_player, Enemy_CLS Enemy, int choiceIndex, Room empty)
            {
                //If they do have it in their inventory, make the enemy take damage
                currentRoom.r_lEnemies[0].take_dmg(1);

                if (currentRoom.r_lEnemies[0].get_health(1) <= 0)
                {
                    //Enemy dies from the attack
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    Console.WriteLine("You sprint twards the enemy with your katana in hand!");
                    Console.WriteLine("You masterfully raise the katana and go to slice the enemy in half when suddenly the katana flys out of your hands and spears the enemy through the chest!");
                    Console.WriteLine(Enemy_CLS.get_who_you_killed()); //using static varible
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    string a_itemdropped = currentRoom.r_lEnemies[0].get_item();
                    Enemy_CLS.enemies_killed++;
                    bool added = c_player.AddItemtoInventory(a_itemdropped);
                    if (added)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine($"You picked up a {a_itemdropped}");
                        Console.WriteLine("----------------------------------------------");

                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------------");

                        Console.WriteLine("You don't have any room in your pockets.");
                    }
                }
                //Enenmy lives & attacks back
                else
                {

                }
                if (currentRoom.r_lChoices[choiceIndex].c_r_cNextRoom != empty && currentRoom.r_lEnemies.Count > 0) //go to the next room, as specified in the nextRoom of that choice in the choiceIndex of the currentRoom
                {
                    currentRoom.r_lEnemies.RemoveAt(0);
                }
                return currentRoom;
            }

            //----------------------------------------------------------
            //definds what to do if the player has a spoon for the attack
            static Room spoon_attack(Room currentRoom, Player c_player, Enemy_CLS Enemy, int choiceIndex, Room empty)
            {
                //If they do have it in their inventory, make the enemy take damage
                currentRoom.r_lEnemies[0].take_dmg(1);

                if (currentRoom.r_lEnemies[0].get_health(1) <= 0)
                {
                    //Enemy dies from the attack
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    Console.WriteLine("You run twards the enemy with your trusty spoon!");
                    Console.WriteLine("While your running, the lights catches off of the spoon blinding the enemy, causing them to fall back into a convienently placed spike!");
                    Console.WriteLine(Enemy_CLS.get_who_you_killed()); //using static varible
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    string a_itemdropped = currentRoom.r_lEnemies[0].get_item();
                    Enemy_CLS.enemies_killed++;
                    bool added = c_player.AddItemtoInventory(a_itemdropped);
                    if (added)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine($"You picked up a {a_itemdropped}");
                        Console.WriteLine("----------------------------------------------");

                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------------");

                        Console.WriteLine("You don't have any room in your pockets.");
                    }
                }
                //Enenmy lives & attacks back
                else
                {

                }
                if (currentRoom.r_lChoices[choiceIndex].c_r_cNextRoom != empty && currentRoom.r_lEnemies.Count > 0) //go to the next room, as specified in the nextRoom of that choice in the choiceIndex of the currentRoom
                {
                    currentRoom.r_lEnemies.RemoveAt(0);
                }
                return currentRoom;
            }
        }
        private static int GetChoiceIndex(Room currentRoom, int maxIndex)
        {
            int choiceIndex;
            //parsing needs an specified output parameter, which is set by saying "out choiceIndex" requiring that I return choiceIndex. if its not, it returns -1...idk I googled it and it says that returns false?!?!?
            if (int.TryParse(Console.ReadLine(), out choiceIndex) && choiceIndex >= 1 && choiceIndex <= maxIndex)
            {
                //choice index is a list, so its got a 0 location, so if choice is 1, its actually choice 0 in the list
                return choiceIndex - 1;
            }
            return -1;
        }
    }
}
