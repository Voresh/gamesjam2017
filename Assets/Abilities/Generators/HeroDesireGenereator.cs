using System.Collections.Generic;
using UnityEngine;

namespace Assets.Abilities
{
    public class HeroDesireGenereator: AbilityDesireGenerator
    {
        [SerializeField]
        private int _startRangeEnd;

        public override void GenerateAndSetDesire(List<Ability> abilities)
        {
            int rangeEnd = _startRangeEnd;
            int i;
            for (i = 0; i < abilities.Count - 1; i++)
            {
                abilities[i].Desire = Random.Range(0, rangeEnd);
                rangeEnd -= abilities[i].Desire;
            }
            abilities[i].Desire = rangeEnd;
        }
    }
}