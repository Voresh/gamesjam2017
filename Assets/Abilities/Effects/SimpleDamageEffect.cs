using UnityEngine;

namespace Assets.Abilities.Effects
{
    public class SimpleDamageEffect : Effect
    {
        [SerializeField]
        private int _damage;

        protected override void AddEffect()
        {
            _target.GetDamage(_damage);
        }

        protected override void RemoveEffect()
        {
            Destroy(gameObject);
        }
    }
}
