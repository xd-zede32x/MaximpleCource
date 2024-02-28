using UnityEngine;
using System.Collections;

namespace Shelfs
{
    public class Shelf : MonoBehaviour, IOpenable
    {
        [SerializeField] private float _moveForwardBy;
        [SerializeField] private float _openCloseTime;

        private Transform _shelfTransform;
        private Vector3 _startPosition;
        private Vector3 _targetPosition;

        private bool _isOpened;

        private void Start()
        {
            _shelfTransform = transform;
            _startPosition = transform.position;
            _targetPosition = transform.position - transform.forward * _moveForwardBy;
        }

        private IEnumerator MoveSelf(bool isOpened)
        {
            float startTime = Time.time;
            float lerpTime = 0f;

            while (lerpTime < 1)
            {
                lerpTime = (Time.time - startTime) / _openCloseTime;

                float lerpValue = Mathf.Lerp(0f, 1f, lerpTime);

                _shelfTransform.position = Vector3.Lerp(_startPosition, isOpened ? _targetPosition : _startPosition, lerpValue);

                yield return null;
            }
        }

        public void OpenOrCLose()
        {
            _isOpened = !_isOpened;
            StopAllCoroutines();
            StartCoroutine(MoveSelf(_isOpened));
        }
    }
}