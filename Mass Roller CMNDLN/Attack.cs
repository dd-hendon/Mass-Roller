using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mass_Roller_CMNDLN
{
    public class Attack
    {
        public string Name { get; set; }
        public int NumberOfAttackers { get; set; }
        public int AttacksPerEntity { get; set; }
        public int Modifier { get; set; }
        public int AC { get; set; }
        public void Initialise()
        {
            Console.WriteLine("\nEnter attacking group name:");
            Name = Console.ReadLine();

            Console.WriteLine("\nEnter number of attackers:");
            NumberOfAttackers = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter attack rolls per attacker:");
            AttacksPerEntity = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter modifier:");
            Modifier = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter AC to beat:");
            AC = Int32.Parse(Console.ReadLine());
        }
        public bool Confirm()
        {
            Console.WriteLine($"\n{NumberOfAttackers} {Name} are attacking {AttacksPerEntity}" +
                $" times each, with a plus {Modifier} to hit, against an AC of {AC}.");
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
        public int[] Roll()
        {
            //Initialize variables
            int Hits = 0;
            int Crits = 0;
            int Numofdice = NumberOfAttackers * AttacksPerEntity;            
            Random dice = new();

            //For loop in range of number of attack dice. 20 is a crit, >= AC is a hit.
            for(int i = 0; i <= Numofdice; i++)
            {
                int result = dice.Next(21);
                if (result == 20)
                    Crits++;
                else if ((result + Modifier) >= AC)
                    Hits++;                
            }

            //Return Hits and Crits as an Int Array
            int[] HitsandCrits = new int[] { Hits, Crits };
            return HitsandCrits;

        }
        public void Result()
        {
            int[] result = Roll();
            Console.WriteLine($"\nThe {Name} " +
                            $"have struck {result[0]} hits " +
                            $"and {result[1]} critical hits!\n");
        }
        
        
            
        
    }
}

