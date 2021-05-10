using MassRollLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mass_Roller_CMNDLN
{
    public static class InitialiseSave
    {
        public static void Initialise(SavingThrow savingThrow)
        {
            Console.WriteLine("Enter the saving throw DC");
            savingThrow.DC = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of creatures making a save");
            savingThrow.NumOfSaves = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Are the saves being made with Advantage," +
                " disadvantage, or neither? Press A, D, or any other key.");
            var choice = Console.ReadLine().ToLower();
            if (choice == "a")
            {
                savingThrow.Advantage = true;
            }
            else if (choice == "b")
            {
                savingThrow.Disadvantage = true;
            }

            Console.WriteLine("Enter damage dice type");
            savingThrow.DamageDiceType = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter amount of damage dice");
            savingThrow.DamageDiceAmount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter any modifier");
            savingThrow.Modifier = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Are the creatures resistant or weak" +
                "to the damage? Press R, W, or any other key.");
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
    }
}
