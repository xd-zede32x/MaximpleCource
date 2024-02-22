using Doors;
using UnityEngine;

namespace Portal
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private LightChanger _lightChanger;

        private Color _lightColor;

        private void Awake() => _lightChanger = FindObjectOfType<LightChanger>();

        public void SetLightColor(Color color) => _lightColor = color;
        public void TurnOnLightThroughPortal() => _lightChanger.TurnOnLight(_lightColor);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMover _))
                TurnOnLightThroughPortal();
        }
    }
}