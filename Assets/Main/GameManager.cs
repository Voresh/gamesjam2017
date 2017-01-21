using System.Collections.Generic;
using System.Linq;
using Assets.Abilities;
using Assets.Abilities.Effects;
using Assets.Units;
using UnityEngine;

namespace Assets.Main
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Current;

        [SerializeField]
        private Level[] _levels;
        private Level _currentLevel;
        [SerializeField]
        private Unit _hero;
        [SerializeField]
        private Unit _muse;

        [SerializeField]
        private List<Effect> _turnEffects = new List<Effect>();
        private List<Effect> _endedEffects = new List<Effect>();

        [SerializeField]
        private AbilityManager _heroAbilityManager;

        [SerializeField]
        private AbilityManager _museAbilityManager;

        public void Awake ()
        {
            Current = this;
            _currentLevel = _levels[0];
            CreateNewAbilities();
        }

        private void CreateNewAbilities()
        {
            _museAbilityManager.CreateNewAbilities();
            _heroAbilityManager.CreateNewAbilities();
        }

        public void NextTurn()
        {
            AddEffectsFromAbilities();

            foreach (var effect in _turnEffects)
            {
                effect.Apply();
            }
            //!!!
            EnemyEndedTurn();
            CreateNewAbilities();
        }

        private void AddEffectsFromAbilities()
        {
            if (_heroAbilityManager.SelectedAbility != null)
            {
                foreach (var effect in _heroAbilityManager.SelectedAbility.Effects)
                {
                    _turnEffects.Add(effect);
                }
            }

            if (_museAbilityManager.SelectedAbility != null)
            {
                foreach (var effect in _museAbilityManager.SelectedAbility.Effects)
                {
                    _turnEffects.Add(effect);
                }
            }
        }

        public void EnemyEndedTurn()
        {
            foreach (var effect in _turnEffects)
            {
                if (effect.RemoveEffectIfEnded())
                {
                    _endedEffects.Add(effect);
                }
            }
            RemoveEndedEffects();
        }

        private void RemoveEndedEffects()
        {
            foreach (var effect in _endedEffects)
            {
                _turnEffects.Remove(effect);
            }
            _endedEffects.Clear();
        }

        public void UnitDied(Unit unit)
        {
            if (unit.gameObject.Equals(_currentLevel.Enemy.gameObject))
            {
                Debug.Log("victory");
            }
            else if (unit == _muse)
            {
                //?
            }
            else if (unit == _hero)
            {
                //defeated
            }
        }
    }
}
