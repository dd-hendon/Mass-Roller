using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassRollLibrary
{
    public class AttackRoll
    {
        public string Name { get; set; }
        public int NumberOfAttackers { get; set; }
        public int AttacksPerEntity { get; set; }
        public int ToHitModifier { get; set; }
        public int AC { get; set; }
        public bool Advantage { get; set; }
        public bool Disadvantage { get; set; }
        public bool Resistance { get; set; }
        public bool Weakness { get; set; }
        public int DamageDiceType { get; set; }
        public int DamageDiceAmount { get; set; }
        public int DamageModifier { get; set; }



        public int[] Roll()
        {
            int Hits = 0;
            int Crits = 0;
            int Numofdice = NumberOfAttackers * AttacksPerEntity;
            Random dice = new();

            if (Advantage)
            {
                for (int i = 0; i <= Numofdice; i++)
                {
                    int result = Math.Max(dice.Next(21), dice.Next(21));
                    if (result == 20)
                        Crits++;
                    else if ((result + ToHitModifier) >= AC)
                        Hits++;
                }

                int[] HitsandCrits = new int[] { Hits, Crits };
                return HitsandCrits;
            }
            else if (Disadvantage)
            {
                for (int i = 0; i <= Numofdice; i++)
                {
                    int result = Math.Min(dice.Next(21), dice.Next(21));
                    if (result == 20)
                        Crits++;
                    else if ((result + ToHitModifier) >= AC)
                        Hits++;
                }

                int[] HitsandCrits = new int[] { Hits, Crits };
                return HitsandCrits;
            }
            else
            {
                for (int i = 0; i <= Numofdice; i++)
                {
                    int result = dice.Next(21);
                    if (result == 20)
                        Crits++;
                    else if ((result + ToHitModifier) >= AC)
                        Hits++;
                }
                                
                int[] HitsandCrits = new int[] { Hits, Crits };
                return HitsandCrits;
            }          
        }

        public int[] Damage(int[] HitsAndCrits)
        {
            int hits = HitsAndCrits[0];
            int crits = HitsAndCrits[1];
            Random dice = new();
            int[] HitsDamage = new int[hits];
            int[] CritsDamage = new int[crits];
            int[] TotalDamage = new int[hits + crits];

            if (Weakness)
            {
                for (int i = 0; i < hits; i++)
                {
                    int damage = DamageModifier;
                    for (int j = 0; j < DamageDiceAmount; j++)
                    {
                        damage += (dice.Next(DamageDiceType + 1) * 2);
                    }
                    HitsDamage[i] = damage;
                }
                for (int i = 0; i < crits; i++)
                {
                    int damage = DamageModifier;
                    for (int j = 0; j < DamageDiceAmount * 2; j++)
                    {
                        damage += (dice.Next(DamageDiceType + 1) * 2);
                    }
                    CritsDamage[i] = damage;
                }
                TotalDamage = CritsDamage.Concat(HitsDamage).ToArray();
                return TotalDamage;
            }
            else if (Resistance)
            {
                for (int i = 0; i < hits; i++)
                {
                    int damage = DamageModifier;
                    for (int j = 0; j < DamageDiceAmount; j++)
                    {
                        damage += (dice.Next(DamageDiceType + 1) / 2);
                    }
                    HitsDamage[i] = damage;
                }
                for (int i = 0; i < crits; i++)
                {
                    int damage = DamageModifier;
                    for (int j = 0; j < DamageDiceAmount * 2; j++)
                    {
                        damage += (dice.Next(DamageDiceType + 1) / 2);
                    }
                    CritsDamage[i] = damage;
                }
                TotalDamage = CritsDamage.Concat(HitsDamage).ToArray();
                return TotalDamage;
            }
            else
            {
                for (int i = 0; i < hits; i++)
                {
                    int damage = DamageModifier;
                    for (int j = 0; j < DamageDiceAmount; j++)
                    {
                        damage += dice.Next(DamageDiceType + 1);
                    }
                    HitsDamage[i] = damage;
                }
                for (int i = 0; i < crits; i++)
                {
                    int damage = DamageModifier;
                    for (int j = 0; j < DamageDiceAmount * 2; j++)
                    {
                        damage += dice.Next(DamageDiceType + 1);
                    }
                    CritsDamage[i] = damage;
                }
                TotalDamage = CritsDamage.Concat(HitsDamage).ToArray();
                return TotalDamage;
            }

            
        }
    }
}
