using UnityEngine;
using System.Collections;

namespace Portal
{
    public class LightChanger : MonoBehaviour
    {
        [SerializeField] private Light _light;
        [SerializeField] private Material _lightbulbMaterial;
        [SerializeField] private Color[] _initializeColors;
        [SerializeField] private float _interpolationTime;

        public Light Light => _light;

        public void TurnOnLight(Color color) => StartCoroutine(WaitToTurnLight(color));
        public void ChangeLightColor(Color color) => _light.color = color;

        private string TurnOnInitialLight(int index)
        {
            _light.color = _initializeColors[index];
            _lightbulbMaterial.SetColor("_EmissionColor", _initializeColors[index]);

            return "Light has been turned on";
        }

        private IEnumerator WaitToTurnLight(Color color)
        {
            float t = 0;

            Color startColor = _light.color;

            while (t < 1)
            {
                Color interpolatedColor = Color.Lerp(startColor, color, t);
                _lightbulbMaterial.SetColor("_EmissionColor", interpolatedColor);
                _light.color = interpolatedColor;
                t += Time.deltaTime / _interpolationTime;

                yield return null;
            }

        }
    }
}