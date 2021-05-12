using System;
using System.Collections.Generic;

namespace MassRollLibrary
{
    public class SavingThrow
    {
        public string Source { get; set; }
        public string Target { get; set; }
        private int _dc;
        public int DC
        {
            get
            {
                return _dc;
            }
            set
            {
                if ((value < 0) && (value > 50))
                    throw new ArgumentException("DC out of range [0 - 50]");                    
                _dc = value;
            }
        }
        private int _numOfSaves;
        public int NumOfSaves
        {
            get
            {
                return _numOfSaves;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Must be one or greater");
                }                    
                else
                {
                    _numOfSaves = value;
                }
            }
        }
        public int SaveModifier { get; set; }
        public bool Advantage { get; set; }
        public bool Disadvantage { get; set; }
        public bool IsCondition { get; set; }
        public string Condition { get; set; }
        public bool IsDamage { get; set; }        
        public bool Resistance { get; set; }
        public bool Weakness  { get; set; }
        public int DamageDiceType { get; set; }
        public int DamageDiceAmount { get; set; }
        public int DamageModifier { get; set; }


        public int[] Roll()
        {
            int totalSaved = 0;
            int totalFailed = 0;
            Random d20 = new();

            if (Advantage)
            {
                for (int i = 0; i < NumOfSaves; i++)
                {
                    bool saved = (Math.Max(d20.Next(21), d20.Next(21)) + SaveModifier >= DC) ? true : false;
                    if (saved) { totalSaved++; }
                    else { totalFailed++; }
                }
                int[] savedAndFailed = new int[] { totalSaved, totalFailed };
                return savedAndFailed;
            }
            else if (Disadvantage)
            {
                for (int i = 0; i < NumOfSaves; i++)
                {
                    bool saved = (Math.Min(d20.Next(21), d20.Next(21)) + SaveModifier >= DC) ? true : false;
                    if (saved) { totalSaved++; }
                    else { totalFailed++; }
                }
                int[] savedAndFailed = new int[] { totalSaved, totalFailed };
                return savedAndFailed;
            }
            else
            {
                for (int i = 0; i < NumOfSaves; i++)
                {
                    bool saved = (d20.Next(21) + SaveModifier >= DC) ? true : false;
                    if (saved) { totalSaved++; }
                    else { totalFailed++; }                        
                }
                int[] savedAndFailed = new int[] { totalSaved, totalFailed };
                return savedAndFailed;
            }
        }

        public List<int[]> Damage(int[] savedAndFailed)
        {
            int saved = savedAndFailed[0];
            int failed = savedAndFailed[1];
            Random dice = new();
            int[] savedDamage = new int[saved];
            int[] failedDamage = new int[failed];

            if (Weakness)
            {
                for (int i = 0; i < saved; i++)
                {
                    int damage = DamageModifier;
                    for (int j = 0; j < DamageDiceAmount; j++)
                    {
                        damage += (dice.Next(DamageDiceType + 1));
                    }
                    savedDamage[i] = damage;
                }
                for (int i = 0; i < failed; i++)
                {
                    int damage = DamageModifier;
                    for (int j = 0; j < DamageDiceAmount; j++)
                    {
                        damage += dice.Next(DamageDiceType + 1) * 2;
                    }
                    failedDamage[i] = damage;
                }
            }
            else if (Resistance)
            {
                for (int i = 0; i < saved; i++)
                {
                    int damage = DamageModifier;
                    for (int j = 0; j < DamageDiceAmount; j++)
                    {
                        damage += (dice.Next(DamageDiceType + 1)) / 4;
                    }
                    savedDamage[i] = damage;
                }
                for (int i = 0; i < failed; i++)
                {
                    int damage = DamageModifier;
                    for (int j = 0; j < DamageDiceAmount; j++)
                    {
                        damage += dice.Next(DamageDiceType + 1) /2;
                    }
                    failedDamage[i] = damage;
                }
            }
            else
            {
                for (int i = 0; i < saved; i++)
                {
                    int damage = DamageModifier;
                    for (int j = 0; j < DamageDiceAmount; j++)
                    {
                        damage += (dice.Next(DamageDiceType + 1)) / 2;
                    }
                    savedDamage[i] = damage;
                }
                for (int i = 0; i < failed; i++)
                {
                    int damage = DamageModifier;
                    for (int j = 0; j < DamageDiceAmount; j++)
                    {
                        damage += dice.Next(DamageDiceType + 1);
                    }
                    failedDamage[i] = damage;
                }
            }            
            
            List<int[]> savedAndFailedDamage = new();
            savedAndFailedDamage.Add(savedDamage);
            savedAndFailedDamage.Add(failedDamage);
            return savedAndFailedDamage;

        }   



    }
}

