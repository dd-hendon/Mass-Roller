using System;

namespace Mass_Roller_CMNDLN
{
    public class InitialiseAttack
    {
        public void Initialise(Attack attack)
        {
            Console.WriteLine("\nEnter attacking group name:");
            attack.Name = Console.ReadLine();

            Console.WriteLine("\nEnter number of attackers:");
            attack.NumberOfAttackers = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter attack rolls per attacker:");
            attack.AttacksPerEntity = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter modifier:");
            attack.Modifier = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter AC to beat:");
            attack.AC = Int32.Parse(Console.ReadLine());
        }
    }
}