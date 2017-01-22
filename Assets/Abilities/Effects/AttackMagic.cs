using UnityEngine;

namespace Assets.Abilities.Effects
{
    public class AttackMagic : Effect
    {
        [SerializeField]
        private int _amount;

        public void Awake()
        {
            UpdateValueField(_amount);
        }

        protected override void AddEffect()
        {
            Target.GetDamage(_amount);
        }

        protected override void RemoveEffect()
        {
            Destroy(gameObject);
        }
    }
}
