using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassRollLibrary;

namespace Mass_Roller_CMNDLN
{
    internal static class Menu
    {
        internal static void Run()
        {
            Header();
            InputHandling();
        }

        public static void Header()
        {
            Console.WriteLine("______________________");
            Console.WriteLine("Welcome to Mass Roller\n");
            Console.WriteLine("       _____");
            Console.WriteLine("      /     \\    ");
            Console.WriteLine("     /       \\   ");
            Console.WriteLine("     \\       /   ");
            Console.WriteLine("      \\_____/    ");
            Console.WriteLine("\nPress A for attack rolls\n" +
                "Press S for saving throws\n" +
                "Press Q to quit\n");
        }

        public static void InputHandling()
        {
            string input = Console.ReadLine().ToLower();

            if (input == "a")
            {
                AttackRoll attackRoll = new();
                Attack.Initialise(attackRoll);
                if (Attack.Confirm(attackRoll))
                {
                    Attack.Result(attackRoll);
                }
                else
                {
                    Console.Clear();
                    Run();
                }
                Console.Clear();
                Run();
            }
            else if (input == "s")
            {
                SavingThrow savingThrow = new();
                Save.Initialise(savingThrow);
                if (savingThrow.IsDamage)
                {
                    Save.SaveWithDamage(savingThrow);
                }
                else
                {
                    Save.SaveOnly(savingThrow);
                }
                Console.ReadLine();
                Run();
            }
            else if (input == "q")
            {
                //quit();
            }
            else
            {
                Console.WriteLine("Please press a valid key!");
                Run();
            }
        }
    }
}
