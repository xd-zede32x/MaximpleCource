using UnityEngine;

namespace Portal
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Light _lightToTurnOn;
        [SerializeField] private LightChanger _lightChanger;

        private void Awake() => _lightChanger = FindObjectOfType<LightChanger>();

        public void SetLightToTurnOn(Light light)
        {
            _lightToTurnOn = light;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMover _))
                _lightChanger.TurnOnLight(_lightToTurnOn);
        }
    }
}