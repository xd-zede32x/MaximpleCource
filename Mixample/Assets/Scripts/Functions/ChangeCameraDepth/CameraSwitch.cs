using UnityEngine;

namespace Test
{
    [RequireComponent(typeof(Camera))]
    public class CameraSwitch : MonoBehaviour
    {
        private const int MaxChangeDepth = 1;
        private const int MinChangeDepth = 0;

        public Camera MainCamera => _mainCamera;

        [SerializeField] private Camera _otherCamera;
        [SerializeField] private PlayerAddScore _playerScore;

        private Camera _mainCamera;

        private void Start() => _mainCamera = GetComponent<Camera>();

        private void Update()
        {
            SwitchCameraDepth(KeyCode.Alpha1, MaxChangeDepth, MinChangeDepth);
            SwitchCameraDepth(KeyCode.Alpha2, MinChangeDepth, MaxChangeDepth);
        }

        private void SwitchCameraDepth(KeyCode key, int min, int max)
        {
            if (Input.GetKeyDown(key))
            {
                _mainCamera.depth = min;
                _otherCamera.depth = max;

                if (_mainCamera.depth == 1)
                    _playerScore.Score++;
            }
        }
    }
}