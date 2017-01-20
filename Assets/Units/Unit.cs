using System.Runtime.InteropServices;
using Assets.Main;
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
            if (_health <= 0)
            {
                Die();
            }
        }

        public void GetHeal(int amount)
        {
            if (_health + amount < _maxHealth)
            {
                _health += amount;
            }
            else
            {
                _health = _maxHealth;
            }
        }

        public void IncreaseStrength()
        {

        }

        public void IncreaseMagicStrength()
        {

        }

        private void Die()
        {
            GameManager.Current.UnitDied(this);
        }
    }
}
