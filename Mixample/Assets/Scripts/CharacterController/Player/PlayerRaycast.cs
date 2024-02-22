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

        private void Update()
        {
            PlayerInputDoorAction();
            PlayerInputShelfAction();
        }

        private void PlayerInputDoorAction()
        {
            if (Input.GetKeyDown(KeyCode.F))
                PerformDoorAction(true);

            if (Input.GetKeyDown(KeyCode.C))
                PerformDoorAction(false);
        }

        private void PlayerInputShelfAction()
        {
            if (Input.GetKeyDown(KeyCode.F))
                PerformShelfAction(true);

            if (Input.GetKeyDown(KeyCode.F))
                PerformShelfAction(false);
        }

        private void PerformDoorAction(bool isOpening)
        {
            if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out RaycastHit hit, _raycastMaxDistance, _layerMaskDoor))
            {
                if (hit.collider.gameObject.TryGetComponent(out Door door))
                {
                    if (isOpening)
                        door.DoorOpining();

                    else
                        door.DoorClosing();
                }
            }
        }

        private void PerformShelfAction(bool isOpening)
        {
            if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out RaycastHit hit, _raycastMaxDistance, _layerMaskShelf))
            {
                if (hit.collider.gameObject.TryGetComponent(out Shelf shelf))
                {
                    if (!isOpening)
                        shelf.ShelfOpining();

                    else
                        shelf.ShelfClosing();
                }
            }
        }
    }
}