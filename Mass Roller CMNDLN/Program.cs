using System;

namespace Mass_Roller_CMNDLN
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            static void Menu()
            {
                Console.WriteLine("Welcome to Mass Roller!\n");
                Console.WriteLine("Press A for attack\n" +
                    "Press S for saving throw\n" +
                    "Press D for damage\n" +
                    "Press Q to quit\n");
                    
                string input = Console.ReadLine().ToLower();


                if (input == "a")
                {
                    Attack attack = new();
                    attack.Initialise();
                    if (attack.Confirm())
                    
                    {
                        attack.Result();                        
                    }
                    else
                    {
                        Menu();
                    }


                }
                else if (input == "s")
                {
                    //savingthrow();
                }
                else if (input == "d")
                {
                    //damage();
                }
                else if (input == "q")
                {
                    //quit();
                }
                else
                {
                    Console.WriteLine("Please press a valid key!");
                    Menu();
                }
            } 
        }
    }
}
