using UnityEngine;

namespace Assets.Abilities
{
    public class EnemyAbilityManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] _abilitiesTemplates;

        private Ability _selectedAbility;

        public Ability SelectedAbility
        {
            get { return _selectedAbility; }
        }

        public void CreateRandomAbility()
        {
            if (_selectedAbility != null)
            {
                RemoveOldAbility();
            }
            int randomNumber = Random.Range(0, _abilitiesTemplates.Length);
            _selectedAbility = Instantiate(_abilitiesTemplates[randomNumber]).GetComponent<Ability>();
            _selectedAbility.Selected = true;
            _selectedAbility.CreateEffects();
        }

        public void RemoveOldAbility()
        {
            _selectedAbility.DestroyUnusedEffects();
            Destroy(_selectedAbility.gameObject);
        }
    }
}
