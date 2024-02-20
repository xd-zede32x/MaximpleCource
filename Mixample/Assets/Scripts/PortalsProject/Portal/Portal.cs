using UnityEngine;

namespace Portal
{
    public class Portal : MonoBehaviour
    {
        private Color _lightColor;
        [SerializeField] private LightChanger _lightChanger;

        private void Awake() => _lightChanger = FindObjectOfType<LightChanger>();

        public void SetLightColor(Color color) => _lightColor = color;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMover _))
                TurnOnLightThroughPortal();
        }

        public void TurnOnLightThroughPortal() => _lightChanger.TurnOnLight(_lightColor);
    }
}