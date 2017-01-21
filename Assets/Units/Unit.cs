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
        private int _maxStrength;
        [SerializeField]
        private int _strength;

        public int Strength
        {
            get { return _strength; }
        }

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

        public void GetPercentHeal(int percent)
        {
            GetHeal(percent * _maxHealth / 100);
        }

        public void IncreaseStrength(int amount)
        {
            _strength += amount;
        }

        public void IncreasePercentStrength(int percent)
        {
            IncreaseStrength(percent * _maxStrength / 100);
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
