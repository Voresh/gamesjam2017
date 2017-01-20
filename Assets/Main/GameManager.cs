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
        private Effect[] _turnEffects;

        public void Awake ()
        {
            Current = this;
        }

        public void Update ()
        {
		
        }

        public void nextTurn()
        {

        }
    }
}
