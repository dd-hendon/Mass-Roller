using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassRollLibrary
{
    internal static class RollType
    {
        internal static Func<Random, int> SetRollType(bool advantage, bool disadvantage)
        {
            if (advantage)
            {
                return AdvantageRoll;
            }
            else if (disadvantage)
            {
                return DisadvantageRoll;
            }
            else
            {
                return StandardRoll;
            }
        }
        private static int AdvantageRoll(Random dice)
        {
            return Math.Max(dice.Next(21), dice.Next(21));
        }
        private static int DisadvantageRoll(Random dice)
        {
            return Math.Min(dice.Next(21), dice.Next(21));
        }
        private static int StandardRoll(Random dice)
        {
            return dice.Next(21);
        }

        internal static Func<Random, int, int> SetDamageRollType(bool resistance, bool weakness)
        {
            if (resistance)
            {
                return ResistanceDamageRoll;
            }
            else if (weakness)
            {
                return WeaknessDamageRoll;
            }
            else
            {
                return StandardDamageRoll;
            }
        }
        private static int ResistanceDamageRoll(Random dice, int damageDiceType)
        {
            return (dice.Next(damageDiceType + 1) / 2);
        }
        private static int WeaknessDamageRoll(Random dice, int damageDiceType)
        {
            return (dice.Next(damageDiceType + 1) * 2);
        }
        private static int StandardDamageRoll(Random dice, int damageDiceType)
        {
            return (dice.Next(damageDiceType + 1));
        }

    }
}
