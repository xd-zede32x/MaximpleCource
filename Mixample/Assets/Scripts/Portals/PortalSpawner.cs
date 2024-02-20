using UnityEngine;
using System.Collections.Generic;

namespace Portal
{
    public class PortalSpawner : MonoBehaviour
    {
        [SerializeField] private float _portalDistance;
        [SerializeField] private Transform _portalParent;
        [SerializeField] private GameObject _portalPrefab;
        [SerializeField] private LightChanger _lightChanger;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            { 
                GameObject portalGameObject = SpawnPortal();

                ChangeLightAndPortalToRandomColor(portalGameObject);
            }
        }

        private GameObject SpawnPortal()
        {
            GameObject portalGameObject = Instantiate(_portalPrefab, _portalParent);
            portalGameObject.transform.localPosition = -Vector3.forward * _portalParent.childCount * _portalDistance + Vector3.up * 2f;

            return portalGameObject;
        }

        private void ChangeLightAndPortalToRandomColor(GameObject portalGameObject)
        {
            Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            portalGameObject.GetComponentInChildren<Portal>().SetLightColor(randomColor);

            List<MeshRenderer> meshRenderers = new List<MeshRenderer>(portalGameObject.GetComponentsInChildren<MeshRenderer>());

            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                if (meshRenderer.TryGetComponent(out LightSwitcher lightSwitcher))
                    continue;

                meshRenderer.material.SetColor("_EmissionColor", randomColor);
            }
        }
    }
}