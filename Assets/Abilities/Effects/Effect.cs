using Assets.Units;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField]
        private Text _valueField;

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

        protected void UpdateValueField(int value)
        {
            if (_valueField != null)
            {
                if (value != 0)
                {
                    _valueField.text = value.ToString();
                }
                else
                {
                    _valueField.text = "-";
                }
            }
        }

        private bool Ended()
        {
            return _turnsDuration == 0;
        }

        protected abstract void AddEffect();

        protected abstract void RemoveEffect();
    }
}
