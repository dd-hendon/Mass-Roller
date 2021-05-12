using MassRollLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mass_Roller_CMNDLN
{
    public static class Attack
    {
        

        public static void Initialise(AttackRoll attackRoll)
        {
            Console.WriteLine("\nEnter attacking group name:");
            attackRoll.Name = Console.ReadLine();

            Console.WriteLine("\nEnter number of attackers:");
            attackRoll.NumberOfAttackers = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter attack rolls per attacker:");
            attackRoll.AttacksPerEntity = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter modifier to hit:");
            attackRoll.ToHitModifier = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter AC to beat:");
            attackRoll.AC = Int32.Parse(Console.ReadLine());
        }
        public static bool Confirm(AttackRoll attackRoll)
        {
            Console.WriteLine($"\n{attackRoll.NumberOfAttackers} {attackRoll.Name} " +
                $"are attacking {attackRoll.AttacksPerEntity}" +
                $" times each, with a plus {attackRoll.ToHitModifier} to hit, against an AC of {attackRoll.AC}.");
            Console.WriteLine("Press Y to Proceed, or any key to return to menu");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        }
        public static void Result()
        {
            int[] result = Roll();
            Console.WriteLine($"\nThe {Name} " +
                            $"have struck {result[0]} hits " +
                            $"and {result[1]} critical hits!\n");
        }
        
        
            
        
    }
}

