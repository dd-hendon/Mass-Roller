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
        public Func<Random, int> AttackRollType { get; private set; }
        public Func<Random, int, int> DamageRollType { get; private set; }

        public int[] ToHitRoll()
        {
            int hits = 0;
            int crits = 0;
            int numOfDice = NumberOfAttackers * AttacksPerEntity;
            Random dice = new();
            AttackRollType = RollType.SetRollType(Advantage, Disadvantage);

            for (int i = 0; i < numOfDice; i++)
            {
                int result = AttackRollType(dice);
                if (result == 20)
                {
                    crits++;
                }
                else if ((result + ToHitModifier) >= AC)
                {
                    hits++;
                }
            }
            int[] hitsandCrits = new int[] { hits, crits };
            return hitsandCrits;
        }

        public int[] DamageRoll(int[] hitsAndCrits)
        {
            int hits = hitsAndCrits[0];
            int crits = hitsAndCrits[1];
            Random dice = new();
            DamageRollType = RollType.SetDamageRollType(Resistance, Weakness);
            int[] hitsDamage = new int[hits];
            int[] critsDamage = new int[crits];
            int[] totalDamage = new int[hits + crits];

            for (int i = 0; i < hits; i++)
            {
                int damage = DamageModifier;
                for (int j = 0; j < DamageDiceAmount; j++)
                {
                    damage += DamageRollType(dice, DamageDiceType);
                }
                hitsDamage[i] = damage;
            }
            for (int i = 0; i < crits; i++)
            {
                int damage = DamageModifier;
                for (int j = 0; j < DamageDiceAmount * 2; j++)
                {
                    damage += DamageRollType(dice, DamageDiceType);
                }
                critsDamage[i] = damage;
            }
            totalDamage = critsDamage.Concat(hitsDamage).ToArray();
            return totalDamage;
        }
    }
}
