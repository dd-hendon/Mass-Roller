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

            bool diceTypeIsInt = false;
            while (diceTypeIsInt == false)
            {
                Console.Write("Damage dice type: ");
                Console.Write("d");
                diceTypeIsInt = int.TryParse(Console.ReadLine(), out int diceType);
                attackRoll.DamageDiceType = diceType;
            }

            bool diceAmountIsInt = false;
            while (diceAmountIsInt == false)
            {                
                Console.Write("Damage dice amount: ");
                var diceAmountInput = Console.ReadLine();
                if (String.IsNullOrEmpty(diceAmountInput))
                {
                    attackRoll.DamageDiceAmount = 1;
                    break;
                }
                diceAmountIsInt = int.TryParse(diceAmountInput, out int diceAmount);
                attackRoll.DamageDiceAmount = diceAmount;
            }

            bool modifierIsInt = false;
            while (modifierIsInt == false)
            {
                Console.Write("Damage modifier: ");
                var damageModifierInput = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(damageModifierInput))
                {
                    break;
                }
                modifierIsInt = int.TryParse(damageModifierInput, out int damageModifier);
                attackRoll.DamageModifier = damageModifier;
            }

            Console.Write("Target Resistance (R), Weakness (W), or neither (Enter): ");
            var damageRollTypeChoice = Console.ReadLine().ToLower();
            if (damageRollTypeChoice == "r")
            {
                attackRoll.Resistance = true;
            }
            else if (damageRollTypeChoice == "w")
            {
                attackRoll.Weakness = true;
            }

        }
        public static bool Confirm(AttackRoll attackRoll)
        {
            Console.WriteLine($"\n{attackRoll.NumberOfAttackers} {attackRoll.Name} " +
                $"are attacking {attackRoll.AttacksPerEntity} " +
                $"times each, with a plus {attackRoll.ToHitModifier} to hit, " +
                $"against an AC of {attackRoll.AC}.");

            Console.WriteLine("Press Y to proceed");
            string confirmChoice = Console.ReadLine().ToLower();
            return confirmChoice == "y";
        }
        public static void Result(AttackRoll attackRoll)
        {
            var roll = attackRoll.ToHitRoll();
            Console.WriteLine($"\n{roll[0]} hits and {roll[1]} crits");
            
            var damageResult = attackRoll.DamageRoll(roll);
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


