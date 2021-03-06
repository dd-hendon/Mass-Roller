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
            Console.WriteLine("\nCondition only? (c)");
            var isDamage = Console.ReadLine().ToLower();
            savingThrow.IsDamage = (isDamage == "c") ? false : true;

            if (savingThrow.IsDamage)
                Console.Write("damage");
            else
                Console.Write("condition");

            Console.WriteLine("\nEnter the effect source");
            savingThrow.Source = Console.ReadLine();
                        
            bool saveDCIsInt = false;
            while (saveDCIsInt == false)
            {
                Console.WriteLine("\nEnter the saving throw DC");                
                saveDCIsInt = int.TryParse(Console.ReadLine(), out int DC);
                savingThrow.DC = DC;
                
            }            

            Console.WriteLine("\nEnter the name of the targets");
            savingThrow.Target = Console.ReadLine();

            bool numOfSavesIsInt = false;            
            while (numOfSavesIsInt == false)                
            {
                Console.WriteLine("\nEnter number of creatures making a save");
                numOfSavesIsInt = int.TryParse(Console.ReadLine(), out int numSaves);
                savingThrow.NumOfSaves = numSaves;
            }


            bool saveModIsInt = false;
            while (saveModIsInt == false)
            {
                Console.WriteLine("\nEnter saving throw modifier");
                var modifier = (Console.ReadLine());
                saveModIsInt = int.TryParse(modifier, out int saveModifier);
                if (saveModIsInt)
                {
                    savingThrow.SaveModifier = saveModifier;
                }
            }
            

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

            //method breakpoint
            if (savingThrow.IsDamage == false)            
                return;

            bool DiceTypeIsInt = false;
            while (DiceTypeIsInt == false)
            {
                Console.WriteLine("\nEnter damage dice type");
                Console.Write("d");
                DiceTypeIsInt = int.TryParse(Console.ReadLine(), out int DiceType);
                savingThrow.DamageDiceType = DiceType;
            }

            bool DiceAmountIsInt = false;
            while (DiceAmountIsInt == false)
            {
                Console.WriteLine("\nEnter amount of damage dice");
                DiceAmountIsInt = int.TryParse(Console.ReadLine(), out int DiceAmount);
                savingThrow.DamageDiceAmount = DiceAmount;
            }


            bool ModifierIsInt = false;
            while (ModifierIsInt == false)
            {
                Console.WriteLine("\nEnter any damage modifier");
                var dmgModInput = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(dmgModInput))
                {
                    break;
                }
                ModifierIsInt = int.TryParse(dmgModInput, out int DmgMod);
                savingThrow.DamageModifier = DmgMod;
            }

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

        public static void SaveOnly(SavingThrow savingThrow)
        {
            var result = savingThrow.Roll();
            Console.WriteLine($"\n\n{result[0]} {savingThrow.Target} " +
                $"saved and {result[1]} failed\n\n\n\n");
        }

        public static void SaveWithDamage(SavingThrow savingThrow)
        {
            var result = savingThrow.Roll();
            var damage = savingThrow.Damage();

            Console.Write($"{result[0]} {savingThrow.Target}" +
                $" made their saves");
            if (result[0] != 0)
                Console.WriteLine($" taking {damage / 2} damage");
                
            Console.Write($"{result[1]} {savingThrow.Target}" +
                $" failed their saves");
            if (result[1] != 0)
                Console.WriteLine($"taking {damage} damage"); 


        }
    }
}
