using System.Collections.Generic;
using Assets.Abilities;
using Assets.Main;
using UnityEngine;

namespace Assets.AI.MuseAI
{
    public class MuseAIControler : MonoBehaviour
    {
        [SerializeField]
        private AbilityManager _abilityManager;
        private AbilityByChance _abilityByChance = new AbilityByChance();

        public void SortAbilitiesByChanseDecrease(List<Ability> abilities)
        {
            abilities.Sort(_abilityByChance);
        }

        public Ability GetMuseChoose(Ability playerSelection, List<Ability> abilities)
        {
            SortAbilitiesByChanseDecrease(abilities);
            int randomNumber = Random.Range(0, 100);
            if (randomNumber > 0 && randomNumber < abilities[0].Chance)
            {
                return abilities[0];
            }
            for (int i = 1; i < abilities.Count; i++)
            {
                if (randomNumber > abilities[i-1].Chance && randomNumber < abilities[i].Chance)
                {
                    return abilities[i];
                }
            }
            return null;
        }
    }
}
