using UnityEngine;

namespace Assets.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _strength;
        [SerializeField] private int _magicStrength;
    }
}
