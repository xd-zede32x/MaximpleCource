using UnityEngine;

namespace Portal
{
    public class PlayerRaycast : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private float _raycastDistance = 2f;
        [SerializeField] private LayerMask _raycastLayerMask;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                RaycastHit hit;

                if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out hit, _raycastDistance, _raycastLayerMask))
                {
                    if (hit.collider.TryGetComponent(out LightSwitcher lightSwitcher))
                        lightSwitcher.TurnOnLight();
                }
            }

            Debug.DrawLine(_mainCamera.transform.position, _mainCamera.transform.position + _mainCamera.transform.forward * _raycastDistance, Color.red);
        }
    }
}