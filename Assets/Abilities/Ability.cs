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
        private bool selected = false;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        public List<Effect> Effects
        {
            get { return _effects; }
        }

        public void Awake()
        {

        }

        public void CreateEffects()
        {
            foreach (var template in _effectsTemplates)
            {
                _effects.Add(Instantiate(template).GetComponent<Effect>());
            }
        }

        public void DestroyUnusedEffects()
        {
            foreach (var effect in _effects)
            {
                if (Selected)
                {
                    if (effect.RemoveEffectIfEnded())
                    {
                        Destroy(effect.gameObject);
                    }
                }
                else
                {
                    Destroy(effect.gameObject);
                }
            }
        }
    }
}
