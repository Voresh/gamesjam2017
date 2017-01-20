using System.Collections.Generic;
using Assets.Abilities.Effects;
using UnityEngine;

namespace Assets.Main
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Current;

        [SerializeField]
        private Level[] _levels;
        private Level _currentLevel;
        [Header("temp")]
        [SerializeField]
        private List<Effect> _turnEffects = new List<Effect>();
        private List<Effect> _nextTurnEffects = new List<Effect>();

        public void Awake ()
        {
            Current = this;
        }

        public void Update ()
        {
		
        }

        public void NextTurn()
        {
            foreach (var effect in _turnEffects)
            {
                effect.Apply();
                if (!effect.Ended())
                {
                    _nextTurnEffects.Add(effect);
                }
            }
            _turnEffects = _nextTurnEffects;
            _nextTurnEffects.Clear();
        }
    }
}
