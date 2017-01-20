using Assets.Abilities.Effects;
using Assets.Units;
using UnityEngine;

namespace Assets.Abilities
{
    public class Ability : MonoBehaviour
    {
        [SerializeField]
        private Unit _abilityOwner;

        [SerializeField]
        private Effect[] _effects;

        public void UseAbility()
        {

        }
    }
}
