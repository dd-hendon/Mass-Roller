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


        Func<Random, int> AttackRollType;
        public int AdvantageRoll(Random dice)
        {
            return Math.Max(dice.Next(21), dice.Next(21));
        }
        public int DisadvantageRoll(Random dice)
        {
            return Math.Min(dice.Next(21), dice.Next(21));
        }
        public int StandardAttackRoll(Random dice)
        {
            return dice.Next(21);
        }
        public void SetAttackRollType()
        {
            if (Advantage)
            {
                AttackRollType = AdvantageRoll;
            }
            else if (Disadvantage)
            {
                AttackRollType = DisadvantageRoll;
            }
            else
            {
                AttackRollType = StandardAttackRoll;
            }
        }
    
        public int[] Roll()
        {
            int Hits = 0;
            int Crits = 0;
            int Numofdice = NumberOfAttackers * AttacksPerEntity;
            Random dice = new();
            SetAttackRollType();

            for (int i = 0; i < Numofdice; i++)
            {
                int result = AttackRollType(dice);
                if (result == 20)
                    Crits++;
                else if ((result + ToHitModifier) >= AC)
                    Hits++;
            }
            int[] HitsandCrits = new int[] { Hits, Crits };
            return HitsandCrits;
        }

        Func<Random, int> DamageRollType;
        public int WeaknessDamageRoll(Random dice)
        {
            return (dice.Next(DamageDiceType + 1) * 2);
        }
        public int ResistanceDamageRoll(Random dice)
        {
            return (dice.Next(DamageDiceType + 1) / 2 );
        }
        public int StandardDamageRoll(Random dice)
        {
            return (dice.Next(DamageDiceType + 1));
        }
        public void SetDamageRollType()
        {
            if(Resistance)
            {
                DamageRollType = ResistanceDamageRoll;
            }
            else if (Weakness)
            {
                DamageRollType = WeaknessDamageRoll;
            }
            else
            {
                DamageRollType = StandardDamageRoll;
            }
        }


        public int[] Damage(int[] HitsAndCrits)
        {
            int hits = HitsAndCrits[0];
            int crits = HitsAndCrits[1];
            Random dice = new();
            SetDamageRollType();
            int[] HitsDamage = new int[hits];
            int[] CritsDamage = new int[crits];
            int[] TotalDamage = new int[hits + crits];

            for (int i = 0; i < hits; i++)
            {
                int damage = DamageModifier;
                for (int j = 0; j < DamageDiceAmount; j++)
                {
                    damage += DamageRollType(dice);
                }
                HitsDamage[i] = damage;
            }
            for (int i = 0; i < crits; i++)
            {
                int damage = DamageModifier;
                for (int j = 0; j < DamageDiceAmount * 2; j++)
                {
                    damage += DamageRollType(dice);
                }
                CritsDamage[i] = damage;
            }
            TotalDamage = CritsDamage.Concat(HitsDamage).ToArray();
            return TotalDamage;

            /*
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
            */
        }
    }
}
