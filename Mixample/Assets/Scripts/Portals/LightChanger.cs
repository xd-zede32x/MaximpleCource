using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Portal
{
    public class LightChanger : MonoBehaviour
    {
        [SerializeField] private List<Light> _lights;
        [SerializeField] private InitialLight _light = InitialLight.Blue;
        [SerializeField] private Material _lightbulbMaterial;

        [SerializeField] private float _time;

        private void Start()
        {
            for (int index = 0; index < _lights.Count; index++)
                _lights[index].gameObject.SetActive(false);

            _lightbulbMaterial.SetColor("_EmissionColor", _lights[1].color);
        }

        public void AddLightToList(Light light) => _lights.Add(light);

        public void TurnOnLight(Light lightToTurnOn) => StartCoroutine(WaitToTurnLight(_time, lightToTurnOn));

        private IEnumerator WaitToTurnLight(float time, Light light)
        {
            yield return new WaitForSeconds(time);

            for (int index = 0; index < _lights.Count; index++)
                _lights[index].gameObject.SetActive(false);

            _lightbulbMaterial.SetColor("_EmissionColor", light.color);
            light.gameObject.SetActive(true);
        }
    }
}