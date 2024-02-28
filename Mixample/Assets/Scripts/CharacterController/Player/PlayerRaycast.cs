using Doors;
using Shelfs;
using UnityEngine;

namespace Player
{
    public class PlayerRaycast : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private float _raycastMaxDistance;

        [SerializeField] private LayerMask _layerMaskDoor;
        [SerializeField] private LayerMask _layerMaskShelf;

        private bool _isOpen = false;

        private void Update()
        {
            PlayerInputDoorAction();
            PlayerInputShelfAction();
        }

        private void PlayerInputDoorAction()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (!_isOpen)
                    PerformDoorAction();
            }
        }

        private void PlayerInputShelfAction()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (_isOpen)
                    PerformShelfAction();
            }
        }

        private void PerformDoorAction()
        {
            if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out RaycastHit hit, _raycastMaxDistance, _layerMaskDoor))
            {
                if (hit.collider.gameObject.TryGetComponent(out Door door))
                    door?.OpenOrCLose();
            }
        }

        private void PerformShelfAction()
        {
            if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out RaycastHit hit, _raycastMaxDistance, _layerMaskShelf))
            {
                if (hit.collider.gameObject.TryGetComponent(out Shelf shelf))
                    shelf?.OpenOrCLose();
            }
        }
    }
}