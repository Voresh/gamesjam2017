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
                //recount chances
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
            foreach (var ability in abilities)
            {
                Debug.Log(ability.Chance);
            }
            int randomNumber = Random.Range(0, 100);
            Debug.Log(randomNumber);
            Debug.Log(0 + " " + abilities[0].Chance);

            for (int i = 1; i < abilities.Count; i++)
            {
                Debug.Log(abilities[i-1].Chance + " " + abilities[i].Chance);
                if (randomNumber >= 0 && randomNumber <= abilities[i].Chance)
                {
                    return abilities[0];
                }
            }
            return abilities[abilities.Count-1];
        }
    }
}
