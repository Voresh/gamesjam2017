using System.Collections.Generic;
using Assets.Abilities;
using Assets.Abilities.Effects;
using Assets.AI.MuseAI;
using Assets.Units;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField]
        private Slider _emotionsSlider;

        [SerializeField]
        private MuseAIControler _museAiControler;

        #region muse penalty

        [SerializeField]
        private int _penaltyTurnsDuration = 4;
        private int _currentPenaltyTurnsDuration;
        private int _afterPenaltyGift = -15;

        #endregion


        #region enemy aggro

        [SerializeField]
        private Slider _aggroSlider;

        #endregion

        public void Awake ()
        {
            Current = this;
            _currentLevel = _levels[0];
            ResetAbilities();
        }

        private void ResetAbilities()
        {
            _museAbilityManager.CreateNewAbilities();
            _heroAbilityManager.CreateNewAbilities();
            _enemyAbilityManager.CreateRandomAbility();
        }

        public void NextTurn()
        {
            _museAbilityManager.SelectAbility(
                _museAiControler.GetMuseChoose(_museAbilityManager.SelectedAbility, _museAbilityManager.CurrentAbilities));

            AddEffectsFromAbilities();
            ApplyTurnEffects();
            RemoveUnneededEffects();
            ResetAbilities();
            UpdatePosiblePenatlies();
        }

        private void ApplyTurnEffects()
        {
            foreach (var effect in _turnEffects)
            {
                effect.Apply();
            }
        }

        private void AddEffectsFromAbilities()
        {
            if (_heroAbilityManager.SelectedAbility != null)
            {
                UpdateEmotionsSlider(-_heroAbilityManager.SelectedAbility.Desire);
                foreach (var effect in _heroAbilityManager.SelectedAbility.Effects)
                {
                    _turnEffects.Add(effect);
                }
            }

            if (_museAbilityManager.SelectedAbility != null)
            {
                if (!PenaltyEnabled())
                {
                    UpdateEmotionsSlider(_museAbilityManager.SelectedAbility.Desire);
                    foreach (var effect in _museAbilityManager.SelectedAbility.Effects)
                    {
                        _turnEffects.Add(effect);
                    }
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

        public void RemoveUnneededEffects()
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


        #region aggro

        public void IncreaseHeroAggro(int amount)
        {
            _aggroSlider.value -= amount/100f;
        }

        public void IncreaseMuseAggro(int amount)
        {
            _aggroSlider.value += amount/100f;
        }

        public int GetAggroValue()
        {
            return Mathf.FloorToInt(_aggroSlider.value * 100f);
        }

        #endregion

        #region other

        private void UpdatePosiblePenatlies()
        {
            if (PenaltyEnabled())
            {
                if (_currentPenaltyTurnsDuration == 1)
                {
                    UpdateEmotionsSlider(_afterPenaltyGift);
                    //Debug.Log("fuck yes");
                }
                _currentPenaltyTurnsDuration--;
            }
        }

        private void MakePenalty()
        {
            if (!PenaltyEnabled())
            {
                _currentPenaltyTurnsDuration = _penaltyTurnsDuration;
            }
        }

        public bool PenaltyEnabled()
        {
            return _currentPenaltyTurnsDuration > 0;
        }

        #endregion

        #region UI

        private void UpdateEmotionsSlider(int emotionsPoints)
        {
            _emotionsSlider.value += emotionsPoints/100f;
            if (_emotionsSlider.value >= 1f)
            {
                //Debug.Log("fuck off");
                MakePenalty();
            }
        }

        #endregion
    }
}
