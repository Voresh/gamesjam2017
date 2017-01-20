using System.Runtime.InteropServices;
using UnityEngine;

namespace Assets.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField]
        private int _maxHealth; //?
        [SerializeField]
        private int _health;
        [SerializeField]
        private int _strength;
        [SerializeField]
        private int _magicStrength;

        public void GetDamage(int damage)
        {
            _health -= damage;
        }

        public void IncreaseStrength()
        {

        }

        public void IncreaseMagicStrength()
        {

        }
    }
}
