using UnityEngine;

namespace Doors
{
    public class Door : MonoBehaviour, IOpenable
    {
        [SerializeField] private float _openCloseTime;
        [SerializeField] private float _rotateByDegrees = -90f;

        private Vector3 _startPosition;
        private Vector3 _targetPosition;

        private float _openToCloseLerp;
        private bool _isOpened;

        private void Start()
        {
            _startPosition = transform.rotation.eulerAngles;
            _targetPosition = transform.rotation.eulerAngles + Vector3.up * _rotateByDegrees;
        }

        private void Update() => DoorAction();

        private void DoorAction()
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(_startPosition), Quaternion.Euler(_targetPosition), _openToCloseLerp);

            _openToCloseLerp = _isOpened ?
                Mathf.Clamp(_openToCloseLerp + Time.deltaTime / _openCloseTime, 0f, 1f)
                : Mathf.Clamp(_openToCloseLerp - Time.deltaTime / _openCloseTime, 0f, 1f);
        }

        public void OpenOrCLose()
        {
            _isOpened = !_isOpened;
        }
    }
}