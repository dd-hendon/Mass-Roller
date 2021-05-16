using MassRollLibrary;
using System;
using System.Linq;

namespace Mass_Roller_CMNDLN
{
    public static class Attack
    {       

        public static void Initialise(AttackRoll attackRoll)
        {
            Console.WriteLine("\nEnter attacking group name:");
            attackRoll.Name = Console.ReadLine();

            bool numOfAttackersIsInt = false;
            while (numOfAttackersIsInt == false)
            {
                Console.WriteLine("\nEnter number of attackers:");
                numOfAttackersIsInt = int.TryParse(Console.ReadLine(), out int numOfAttackers);
                attackRoll.NumberOfAttackers = numOfAttackers;
            }

            bool attacksPerEntityIsInt = false;
            while (attacksPerEntityIsInt == false)
            {
                Console.WriteLine("\nEnter attack rolls per attacker:");
                var attacksPerEntityInput = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(attacksPerEntityInput))
                {
                    attackRoll.AttacksPerEntity = 1;
                    break;
                }
                attacksPerEntityIsInt = int.TryParse(attacksPerEntityInput, out int attacksPerEntity);
                attackRoll.AttacksPerEntity = attacksPerEntity;
            }

            bool toHitModIsInt = false;
            while (toHitModIsInt == false)
            {
                Console.WriteLine("\nEnter modifier to hit:");
                toHitModIsInt = int.TryParse(Console.ReadLine(), out int toHitMod);
                attackRoll.ToHitModifier = toHitMod;
            }

            bool acIsInt = false;
            while (acIsInt == false)
            {
                Console.WriteLine("\nEnter AC to beat:");
                acIsInt = int.TryParse(Console.ReadLine(), out int AC);
                attackRoll.AC = AC;
            }

            Console.WriteLine("\nAdvantage (a), disadvantage (d) or neither (any)");
            var choice = Console.ReadLine().ToLower();
            if (choice == "a")
            {
                attackRoll.Advantage = true;
            }
            else if (choice == "d")
            {
                attackRoll.Disadvantage = true;
            }

            bool DiceTypeIsInt = false;
            while (DiceTypeIsInt == false)
            {
                Console.WriteLine("\nEnter damage dice type");
                Console.Write("d");
                DiceTypeIsInt = int.TryParse(Console.ReadLine(), out int DiceType);
                attackRoll.DamageDiceType = DiceType;
            }

            bool DiceAmountIsInt = false;
            while (DiceAmountIsInt == false)
            {                
                Console.WriteLine("\nEnter amount of damage dice");
                var DiceAmountInput = Console.ReadLine();
                if (String.IsNullOrEmpty(DiceAmountInput))
                {
                    attackRoll.DamageDiceAmount = 1;
                    break;
                }
                DiceAmountIsInt = int.TryParse(DiceAmountInput, out int DiceAmount);
                attackRoll.DamageDiceAmount = DiceAmount;
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
                attackRoll.DamageModifier = DmgMod;
            }

            Console.WriteLine("\nAre the creatures resistant or weak" +
                " to the damage? Press R, W, or any other key.");
            var choice2 = Console.ReadLine().ToLower();
            if (choice2 == "r")
            {
                attackRoll.Resistance = true;
            }
            else if (choice2 == "w")
            {
                attackRoll.Weakness = true;
            }

        }
        public static bool Confirm(AttackRoll attackRoll)
        {
            Console.WriteLine($"\n{attackRoll.NumberOfAttackers} {attackRoll.Name} " +
                $"are attacking {attackRoll.AttacksPerEntity}" +
                $" times each, with a plus {attackRoll.ToHitModifier} to hit, against an AC of {attackRoll.AC}.");
            Console.WriteLine("Press Y to proceed");
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
        public static void Result(AttackRoll attackRoll)
        {
            var roll = attackRoll.Roll();
            Console.WriteLine($"\n{roll[0]} hits and {roll[1]} crits");
            
            var damageResult = attackRoll.Damage(roll);
            var totalDamage = damageResult.Sum();

            Console.WriteLine($"\nFor a total of {totalDamage} damage");
            Console.WriteLine("\nIndividual hits:");
            
            foreach (var hit in damageResult)
            {
                Console.Write($"{hit}, ");
            }

            Console.WriteLine("\n");
            Console.ReadLine();
        }

    }
    




}


