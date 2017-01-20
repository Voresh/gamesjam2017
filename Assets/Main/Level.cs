using Assets.Units;
using UnityEngine;

namespace Assets.Main
{
    public class Level : MonoBehaviour
    {
        [SerializeField]
        private Unit _enemy;

        public Unit Enemy
        {
            get { return _enemy; }
        }
    }
}
