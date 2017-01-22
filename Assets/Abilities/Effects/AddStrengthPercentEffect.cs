using UnityEngine;

namespace Assets.Abilities.Effects
{
    public class AddStrengthPercentEffect : Effect
    {
        [SerializeField]
        private int _percent;

        public void Awake()
        {
            UpdateValueField(_percent);
        }

        protected override void AddEffect()
        {
            Target.IncreasePercentStrength(_percent);
        }

        protected override void RemoveEffect()
        {
            Target.IncreasePercentStrength(-_percent);
            Destroy(gameObject);
        }
    }
}
