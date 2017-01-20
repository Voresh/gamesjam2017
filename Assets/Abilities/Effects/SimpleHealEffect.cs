﻿using UnityEngine;

namespace Assets.Abilities.Effects
{
    public class SimpleHealEffect : Effect
    {
        [SerializeField]
        private int _amount;

        protected override void AddEffect()
        {
            Target.GetHeal(_amount);
        }

        protected override void RemoveEffect()
        {
            Destroy(gameObject);
        }
    }
}