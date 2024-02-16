using UnityEngine;
using System.Collections.Generic;

namespace Portal
{
    public class PortalSpawner : MonoBehaviour
    {
        [SerializeField] private float _portalDistance;
        [SerializeField] private Transform _portalParent;
        [SerializeField] private GameObject _lightPrefab;
        [SerializeField] private GameObject _portalPrefab;
        [SerializeField] private LightChanger _lightChanger;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Light light = SpawnLight();
                _lightChanger.AddLightToList(light);

                GameObject portalGameObject = SpawnPortal();
                portalGameObject.GetComponentInChildren<Portal>().SetLightToTurnOn(light);

                ChangeLightAndPortalToRandomColor(portalGameObject, light);
            }
        }

        private Light SpawnLight()
        {
            GameObject lightGameObject = Instantiate(_lightPrefab, _lightChanger.transform);
            lightGameObject.transform.localPosition = Vector3.zero;
            lightGameObject.SetActive(false);   

            return lightGameObject.GetComponent<Light>();
        }

        private GameObject SpawnPortal()
        {
            GameObject portalGameObject = Instantiate(_portalPrefab, _portalParent);
            portalGameObject.transform.localPosition = -Vector3.forward * _portalParent.childCount * _portalDistance + Vector3.up * 2f;

            return portalGameObject;
        }

        private void ChangeLightAndPortalToRandomColor(GameObject portalGameObject, Light light)
        {
            Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            light.color = randomColor;

            List<MeshRenderer> meshRenderers = new List<MeshRenderer>(portalGameObject.GetComponentsInChildren<MeshRenderer>());

            foreach (MeshRenderer meshRenderer in meshRenderers)
                meshRenderer.material.SetColor("_EmissionColor", randomColor);
        }
    }
}