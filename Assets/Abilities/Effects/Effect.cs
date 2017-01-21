using Assets.Units;
using UnityEngine;

namespace Assets.Abilities.Effects
{
    public abstract class Effect : MonoBehaviour
    {
        [SerializeField]
        private int _turnsDuration = 1;
        [SerializeField]
        protected Unit Target;
        [SerializeField]
        protected Unit Caster;
        //[SerializeField]
        private bool _added;
        [SerializeField]
        private bool _repeatable;

        public void Apply()
        {
            if (!_added || _repeatable)
            {
                AddEffect();
                _added = true;
            }
            _turnsDuration--;
        }

        public bool RemoveEffectIfEnded()
        {
            if (Ended())
            {
                RemoveEffect();
            }
            return Ended();
        }

        private bool Ended()
        {
            return _turnsDuration == 0;
        }

        protected abstract void AddEffect();

        protected abstract void RemoveEffect();
    }
}
