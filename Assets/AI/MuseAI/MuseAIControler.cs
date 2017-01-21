using Assets.Abilities;
using Assets.Main;
using UnityEngine;

namespace Assets.AI.MuseAI
{
    public class MuseAIControler : MonoBehaviour
    {
        [SerializeField]
        private AbilityManager _abilityManager;

        public void SortAbilitiesByChanseDecrease()
        {
            foreach (var a in  _abilityManager.CurrentAbilities)
            {
                Debug.Log(a.Chance);
            }
            _abilityManager.CurrentAbilities.Sort(new AbilityByChance());
            Debug.Log("next");
            foreach (var a in  _abilityManager.CurrentAbilities)
            {
                Debug.Log(a.Chance);
            }
        }
    }
}
