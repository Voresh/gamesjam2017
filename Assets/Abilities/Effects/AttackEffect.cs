namespace Assets.Abilities.Effects
{
    public class AttackEffect : Effect
    {
        public void Awake()
        {
            UpdateValueField(0);
        }

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
