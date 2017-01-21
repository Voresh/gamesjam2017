using Assets.Main;
using UnityEngine;

namespace Assets.Abilities.Effects
{
    public class IncreaseHeroAggroEffect : Effect
    {
        [SerializeField] private int _amount;

        protected override void AddEffect()
        {
            GameManager.Current.IncreaseHeroAggro(_amount);
        }

        protected override void RemoveEffect()
        {
            GameManager.Current.IncreaseHeroAggro(-_amount);
            Destroy(gameObject);
        }
    }
}
