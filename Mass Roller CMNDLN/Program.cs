using System;
using MassRollLibrary;

namespace Mass_Roller_CMNDLN
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            static void Menu()
            {
                Console.WriteLine("______________________");
                Console.WriteLine("Welcome to Mass Roller\n");
                Console.WriteLine("       _____");
                Console.WriteLine("      /     \\    ");
                Console.WriteLine("     /       \\   ");
                Console.WriteLine("     \\       /   ");
                Console.WriteLine("      \\_____/    ");
                Console.WriteLine("\nPress A for attack rolls\n" +
                    "Press S for saving throws\n\n" +
                    //"Press D for damage\n" +
                    "Press Q to quit\n");
                    
                string input = Console.ReadLine().ToLower();


                if (input == "a")
                {
                    //AttackRoll attack = new();
                    //Attack.Initialise(attack);
                    //if (attack.Confirm())
                    //    attack.Result();
                    //else
                        Menu();                 


                }
                else if (input == "s")
                {
                    SavingThrow savingThrow = new();
                    Save.Initialise(savingThrow);
                    if (savingThrow.IsDamage)
                        Save.SaveWithDamage(savingThrow);
                    else
                        Save.SaveOnly(savingThrow);
                    Console.ReadLine();
                    Menu();
                }
                else if (input == "d")
                {
                    //damage();
                }
                else if (input == "q")
                {
                    //quit();
                }
                else
                {
                    Console.WriteLine("Please press a valid key!");
                    Menu();
                }
            } 
        }

        
    }
}
