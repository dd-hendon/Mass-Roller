using MassRollLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mass_Roller_CMNDLN
{
    public static class Save
    {
        public static void Initialise(SavingThrow savingThrow)
        {
            Console.WriteLine("a\nv\ne\n");

            Console.WriteLine("\nDamage (d) or Condition (c) only?\n");
            var isdamage = Console.ReadLine().ToLower();
            savingThrow.IsDamage = (isdamage == "d") ? true : false;

            if (savingThrow.IsDamage)
                Console.WriteLine("a\nm\na\ng\ne");
            else
                Console.WriteLine("o\nn\nd\ni\nt\ni\no\nn");

            Console.WriteLine("\nEnter the effect source");
            savingThrow.Source = Console.ReadLine();
            
            Console.WriteLine("\nEnter the saving throw DC");
            savingThrow.DC = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the name of the targets");
            savingThrow.Target = Console.ReadLine();

            Console.WriteLine("\nEnter number of creatures making a save");
            savingThrow.NumOfSaves = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter saving throw modifier");
            savingThrow.SaveModifier = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nAdvantage (a), disadvantage (d) or neither (any)");
            var choice = Console.ReadLine().ToLower();
            if (choice == "a")
            {
                savingThrow.Advantage = true;
            }
            else if (choice == "d")
            {
                savingThrow.Disadvantage = true;
            }

            if (savingThrow.IsDamage == false)            
                return;
            
            Console.WriteLine("\nEnter damage dice type");
            Console.Write("d");
            savingThrow.DamageDiceType = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter amount of damage dice");
            savingThrow.DamageDiceAmount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter any modifier");
            savingThrow.DamageModifier = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nAre the creatures resistant or weak" +
                " to the damage? Press R, W, or any other key.");
            var choice2 = Console.ReadLine().ToLower();
            if (choice2 == "r")
            {
                savingThrow.Resistance = true;
            }
            else if (choice2 == "w")
            {
                savingThrow.Weakness = true;
            }
        }

        public static void SaveAndDamage(SavingThrow savingThrow)
        {
            var result = savingThrow.Damage(savingThrow.Roll());
            var saved = result[0];
            var failed = result[1];            

            Console.WriteLine("\n\nThose that saved recieved:");
            foreach (var damage in saved)
            {
                Console.Write(damage + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("\nThose that failed recieved:");
            foreach (var damage in failed)
            {
                Console.Write(damage + ", ");
            }
            Console.WriteLine();
        }

        public static void SaveOnly(SavingThrow savingThrow)
        {
            var result = savingThrow.Roll();
            Console.WriteLine($"\n\n{result[0]} {savingThrow.Target} " +
                $"saved and {result[1]} failed\n\n\n\n");
        }
    }
}
