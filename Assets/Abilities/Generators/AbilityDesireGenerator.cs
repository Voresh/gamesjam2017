using System.Collections.Generic;
using UnityEngine;

namespace Assets.Abilities
{
    public abstract class AbilityDesireGenerator: MonoBehaviour
    {
        public abstract void GenerateAndSetDesire(List<Ability> abilities);
    }
}