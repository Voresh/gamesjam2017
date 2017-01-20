using UnityEngine;

namespace Assets.Abilities.Effects
{
    public class AddStrengthEffect : Effect
    {
        [SerializeField]
        private int _amount;

        protected override void AddEffect()
        {
            Target.IncreaseStrength(_amount);
        }

        protected override void RemoveEffect()
        {
            Target.DecreaseStrength(_amount);
            Destroy(gameObject);
        }
    }
}
