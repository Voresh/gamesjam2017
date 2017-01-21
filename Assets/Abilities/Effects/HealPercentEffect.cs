using UnityEngine;

namespace Assets.Abilities.Effects
{
    public class HealPercentEffect : Effect
    {
        [SerializeField]
        private int _percent;

        protected override void AddEffect()
        {
            Target.GetPercentHeal(_percent);
        }

        protected override void RemoveEffect()
        {
            Destroy(gameObject);
        }
    }
}
