using System.Collections.Generic;
using Assets.Abilities.Effects;
using UnityEngine;

namespace Assets.Abilities
{
    public class Ability : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _effectsTemplates;
        private List<Effect> _effects = new List<Effect>();

        public List<Effect> Effects
        {
            get { return _effects; }
        }

        public void Awake()
        {
            foreach (var template in _effectsTemplates)
            {
                _effects.Add(Instantiate(template).GetComponent<Effect>());
            }
        }

        public void SelectAbility()
        {

        }

        public void DeselectAbility()
        {

        }
    }
}
