using Assets.Units;
using UnityEngine;

namespace Assets.Abilities.Effects
{
    public abstract class Effect : MonoBehaviour
    {
        [SerializeField]
        private int _turnsDuration = 1;
        [SerializeField]
        protected Unit _target;

        public void Apply()
        {
            AddEffect();
            _turnsDuration--;
            if (!Ended())
            {
                RemoveEffect();
            }
        }

        public bool Ended()
        {
            return _turnsDuration != 0;
        }

        protected abstract void AddEffect();

        protected abstract void RemoveEffect();
    }
}
