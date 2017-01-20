using System.Collections.Generic;
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

        [Header("temp")]
        [SerializeField]
        private List<Effect> _turnEffects = new List<Effect>();
        private List<Effect> _endedEffects = new List<Effect>();

        public void Awake ()
        {
            Current = this;
            _currentLevel = _levels[0];
        }

        public void Update ()
        {
		
        }

        public void AddEffect(GameObject effect)
        {
            Effect newEffect = Instantiate(effect).GetComponent<Effect>();
            _turnEffects.Add(newEffect);
        }

        public void NextTurn()
        {
            foreach (var effect in _turnEffects)
            {
                effect.Apply();
            }
            //!!!
            EnemyEndedTurn();
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
