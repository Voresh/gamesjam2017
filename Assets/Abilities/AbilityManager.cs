using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Abilities
{
    public class AbilityManager : MonoBehaviour
    {
        [SerializeField]
        private Transform canvas;
        [SerializeField]
        private GameObject[] _abilitiesTemplates;
        [SerializeField]
        private Vector3[] _abilitiesPlaces;
        [Header("temp")]
        [SerializeField]
        private List<Ability> _currentAbilities = new List<Ability>();

        public void CreateNewAbilities()
        {
            RemoveOldAbilities();
            for (int i = 0; i < _abilitiesPlaces.Length; i++)
            {
                int uniqueId = GetRandomUniqueAbilityId();
                RectTransform ability = Instantiate(_abilitiesTemplates[uniqueId]).GetComponent<RectTransform>();
                ability.SetParent(canvas);
                ability.anchoredPosition = _abilitiesPlaces[i];
                _currentAbilities.Add(ability.GetComponent<Ability>());
                ability.GetComponent<Ability>().CreateEffects();
            }
        }

        public int GetRandomUniqueAbilityId()
        {
            int randomNumber = Random.Range(0, _abilitiesTemplates.Length);
            while (CurrentAbilitiesContains(_abilitiesTemplates[randomNumber].GetComponent<Ability>()))
            {
                randomNumber = Random.Range(0, _abilitiesTemplates.Length);
            }
            return randomNumber;
        }

        public bool CurrentAbilitiesContains(Ability ability)
        {
            foreach (var currAbility in _currentAbilities)
            {
                if (currAbility.TheSame(ability.Id))
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveOldAbilities()
        {
            foreach (var ability in _currentAbilities)
            {
                ability.DestroyUnusedEffects();
                Destroy(ability.gameObject);
            }
            _currentAbilities.Clear();
        }
    }
}
