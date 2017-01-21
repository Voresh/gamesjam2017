using System.Collections.Generic;
using Assets.Abilities.Effects;
using UnityEngine;

namespace Assets.Abilities
{
    public class Ability : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _effectsTemplates;
        [SerializeField]
        private int _id;

        [SerializeField]
        private int _chance;

        [SerializeField]
        private int _desire;

        public int Desire
        {
            get { return _desire; }
            set { _desire = value; }
        }

        public int Chance
        {
            get { return _chance; }
            set { _chance = value; }
        }

        public int Id
        {
            get { return _id; }
        }

        private List<Effect> _effects = new List<Effect>();
        private bool selected;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        public List<Effect> Effects
        {
            get { return _effects; }
        }

        public bool TheSame(int id)
        {
            return _id == id;
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
