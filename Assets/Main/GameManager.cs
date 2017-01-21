using System.Collections.Generic;
using Assets.Abilities;
using Assets.Abilities.Effects;
using Assets.AI.MuseAI;
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
        [SerializeField]
        private EnemyAbilityManager _enemyAbilityManager;

        [SerializeField] private MuseAIControler _museAiControler;

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
            _enemyAbilityManager.CreateRandomAbility();
        }

        public void NextTurn()
        {
            //get muse ability here by random
            _museAiControler.SortAbilitiesByChanseDecrease();

            AddEffectsFromAbilities();

            foreach (var effect in _turnEffects)
            {
                effect.Apply();
            }
            //!!!
            EnemyEndedTurn();
            CreateNewAbilities();
        }

        private void RandomiseMuseAbility()
        {
            if (_museAbilityManager.SelectedAbility != null)
            {
                int choise = Random.Range(0, 100);

            }
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

            if (_enemyAbilityManager.SelectedAbility != null)
            {
                foreach (var effect in _enemyAbilityManager.SelectedAbility.Effects)
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
