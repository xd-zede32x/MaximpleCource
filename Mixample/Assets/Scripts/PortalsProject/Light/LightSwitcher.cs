using UnityEngine;

namespace Portal
{
    public class LightSwitcher : MonoBehaviour
    {
        [SerializeField] private Portal _portal;

        public void TurnOnLight() => _portal.TurnOnLightThroughPortal();
    }
}