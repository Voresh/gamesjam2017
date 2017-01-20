using System.Runtime.InteropServices;
using Assets.Main;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField]
        private int _maxHealth = 100;
        [SerializeField]
        private int _health = 100;
        [SerializeField]
        private int _strength;
        [SerializeField]
        private int _magicStrength;

        [SerializeField]
        private Image _healhbar;

        public void Awake()
        {
            UpdateHealthbar();
        }

        private void UpdateHealthbar()
        {
            _healhbar.fillAmount = (float) _health / _maxHealth;
        }

        public void GetDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
            UpdateHealthbar();
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
            UpdateHealthbar();
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
