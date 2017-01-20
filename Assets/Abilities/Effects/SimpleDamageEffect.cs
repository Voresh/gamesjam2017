﻿using UnityEngine;

namespace Assets.Abilities.Effects
{
    public class SimpleDamageEffect : Effect
    {
        [SerializeField]
        private int _damage;

        protected override void AddEffect()
        {
            Target.GetDamage(_damage);
        }

        protected override void RemoveEffect()
        {
            Destroy(gameObject);
        }
    }
}
