using System.Collections.Generic;

namespace Assets.Abilities
{
    public class MuseDesireGenereator: AbilityDesireGenerator
    {
        public override void GenerateAndSetDesire(List<Ability> abilities)
        {
            foreach (var ability in abilities)
            {
                ability.Desire = (100 - ability.Chance) / 4;
            }
        }
    }
}