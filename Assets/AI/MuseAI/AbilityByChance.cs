using System.Collections.Generic;
using Assets.Abilities;

namespace Assets.Main
{
    public class AbilityByChance : IComparer<Ability>
    {
        public int Compare(Ability x, Ability y)
        {
            if (x.Chance > y.Chance)
            {
                return -1;
            }

            if (x.Chance < y.Chance)
            {
                return 1;
            }

            return 0;
        }
    }
}