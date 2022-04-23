using MassRollLibrary;
using System;
using System.Linq;

namespace Mass_Roller_CMNDLN
{
    public static class Attack
    {       

        public static void Initialise(AttackRoll attackRoll)
        {
            Console.Write("Attacking group name: ");
            attackRoll.Name = Console.ReadLine();

            bool numOfAttackersIsInt = false;
            while (numOfAttackersIsInt == false)
            {
                Console.Write("Number of attackers: ");
                numOfAttackersIsInt = int.TryParse(Console.ReadLine(), out int numOfAttackers);
                attackRoll.NumberOfAttackers = numOfAttackers;
            }

            bool attacksPerEntityIsInt = false;
            while (attacksPerEntityIsInt == false)
            {
                Console.Write("Attack rolls per attacker: ");
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
                Console.Write("Modifier to hit: ");
                toHitModIsInt = int.TryParse(Console.ReadLine(), out int toHitMod);
                attackRoll.ToHitModifier = toHitMod;
            }

            bool acIsInt = false;
            while (acIsInt == false)
            {
                Console.Write("AC to beat: ");
                acIsInt = int.TryParse(Console.ReadLine(), out int AC);
                attackRoll.AC = AC;
            }

            Console.Write("Advantage (A), Disadvantage (D) or neither (Enter): ");
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
                Console.Write("Damage dice type: ");
                Console.Write("d");
                DiceTypeIsInt = int.TryParse(Console.ReadLine(), out int DiceType);
                attackRoll.DamageDiceType = DiceType;
            }

            bool DiceAmountIsInt = false;
            while (DiceAmountIsInt == false)
            {                
                Console.Write("Damage dice: ");
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
                Console.Write("Damage modifier: ");
                var dmgModInput = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(dmgModInput))
                {
                    break;
                }
                ModifierIsInt = int.TryParse(dmgModInput, out int DmgMod);
                attackRoll.DamageModifier = DmgMod;
            }

            Console.Write("Target Resistance (R), Weakness (W), or neither (Enter): ");
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


