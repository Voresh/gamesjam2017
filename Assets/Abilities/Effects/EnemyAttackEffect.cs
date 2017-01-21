using Assets.Main;
using Assets.Units;
using UnityEngine;

namespace Assets.Abilities.Effects
{
    public class EnemyAttackEffect : Effect
    {
        [SerializeField]
        private Unit _hero;
        [SerializeField]
        private Unit _muse;

        protected override void AddEffect()
        {
            if (Random.Range(0, 100) < GameManager.Current.GetAggroValue())
            {
                Target = _hero;
            }
            else
            {
                Target = _muse;
            }
            Target.GetDamage(Caster.Strength);
        }

        protected override void RemoveEffect()
        {
            Destroy(gameObject);
        }
    }
}
