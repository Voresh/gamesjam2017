using UnityEngine;

namespace Assets
{
    public class SwitchGO : MonoBehaviour
    {
        [SerializeField]
        private GameObject _switchable;

        public void Switch()
        {
            _switchable.SetActive(!_switchable.activeSelf);
        }
    }
}
