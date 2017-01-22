using System.Collections.Generic;
using UnityEngine;

namespace Assets.Abilities
{
    public class AbilityManager : MonoBehaviour
    {
        [SerializeField]
        private Transform _canvas;
        [SerializeField]
        private GameObject[] _abilitiesTemplates;
        [SerializeField]
        private Vector3[] _abilitiesPlaces;
        private List<Ability> _currentAbilities = new List<Ability>();

        public List<Ability> CurrentAbilities
        {
            get { return _currentAbilities; }
        }

        [SerializeField]
        private Ability _selectedAbility;

        [SerializeField]
        private AbilityDesireGenerator _abilityDesireGenerator;

        public Ability SelectedAbility
        {
            get { return _selectedAbility; }
        }

        public void CreateNewAbilities()
        {
            RemoveOldAbilities();
            for (int i = 0; i < _abilitiesPlaces.Length; i++)
            {
                int uniqueId = GetRandomUniqueAbilityId();
                RectTransform ability = Instantiate(_abilitiesTemplates[uniqueId]).GetComponent<RectTransform>();
                ability.SetParent(_canvas);
                ability.SetSiblingIndex(6);
                ability.anchoredPosition = _abilitiesPlaces[i];
                _currentAbilities.Add(ability.GetComponent<Ability>());
                ability.GetComponent<Ability>().CreateEffects();
            }
            SetRandomChances();
            _abilityDesireGenerator.GenerateAndSetDesire(_currentAbilities);
        }

        public void SetRandomChances()
        {
            int rangeEnd = 100; //percent
            int i;
            for (i = 0; i < _currentAbilities.Count - 1; i++)
            {
                _currentAbilities[i].Chance = Random.Range(0, rangeEnd);
                rangeEnd -= _currentAbilities[i].Chance;
            }
            _currentAbilities[i].Chance = rangeEnd;
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

        public void SelectAbility(Ability ability)
        {
            if (_selectedAbility != null)
            {
                _selectedAbility.Selected = false;
            }
            _selectedAbility = ability;
            _selectedAbility.Selected = true;
        }
    }
}
