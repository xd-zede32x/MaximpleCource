using UnityEngine;

namespace LerpExample
{
    public class LerpExample : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _objectMeshRender;
        [SerializeField] private MeshRenderer _startObjectMeshRenderer;
        [SerializeField] private MeshRenderer _endObjectMeshRenderer;

        [SerializeField] private Transform _objectMover;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private Transform _endPosition;

        [SerializeField, Range(0, 1)] private float _t;

        private Color _startObjectColor;
        private Color _endObjectColor;

        private void Start() => ReceivingMeshRenderer();
        private void Update() => SmoothColorChange();

        private void ReceivingMeshRenderer()
        {
            _startObjectColor = _startObjectMeshRenderer.material.GetColor("_EmissionColor");
            _endObjectColor = _endObjectMeshRenderer.material.GetColor("_EmissionColor");
        }

        private void SmoothColorChange()
        {
            _objectMover.position = Vector3.Lerp(_startPosition.position, _endPosition.position, _t);
            Color objectColor = Color.Lerp(_startObjectColor, _endObjectColor, _t);
            _objectMeshRender.material.SetColor("_EmissionColor", objectColor);
        }
    }
}