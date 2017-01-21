using System.Collections.Generic;
using Assets.Abilities;
using Assets.Main;
using UnityEngine;

namespace Assets.AI.MuseAI
{
    public class MuseAIControler : MonoBehaviour
    {
        private AbilityByChance _abilityByChance = new AbilityByChance();
        [SerializeField]
        private int _playerSelectionChance = 70;

        public void SortAbilitiesByChanseDecrease(List<Ability> abilities)
        {
            abilities.Sort(_abilityByChance);
        }

        public Ability GetMuseChoose(Ability playerSelection, List<Ability> abilities)
        {
            if (playerSelection != null)
            {
                int chanceSum = 0;
                foreach (var ability in abilities)
                {
                    chanceSum += ability.Chance;
                }
                chanceSum -= playerSelection.Chance;
                foreach (var ability in abilities)
                {
                    ability.Chance = (100 - _playerSelectionChance) * (ability.Chance / chanceSum);
                }
                playerSelection.Chance = _playerSelectionChance;
            }
            SortAbilitiesByChanseDecrease(abilities);
            int randomNumber = Random.Range(0, 100);
            for (int i = 1; i < abilities.Count; i++)
            {
                if (randomNumber >= 0 && randomNumber <= abilities[i].Chance)
                {
                    return abilities[0];
                }
            }
            return abilities[abilities.Count-1];
        }
    }
}
