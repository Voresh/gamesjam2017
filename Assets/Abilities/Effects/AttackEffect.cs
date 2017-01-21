namespace Assets.Abilities.Effects
{
    public class AttackEffect : Effect
    {
        protected override void AddEffect()
        {
            Target.GetDamage(Caster.Strength);
        }

        protected override void RemoveEffect()
        {
            Destroy(gameObject);
        }
    }
}
