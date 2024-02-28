using Doors;
using TMPro;
using Shelfs;
using UnityEngine;
using SwitchCamera;

public class CodeLock : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private Shelf _shelf;
    [SerializeField] private IOpenable _openable;
    [SerializeField] private string _password = "1234";
    [SerializeField] private Camera _cameraCastle;
    [SerializeField] private MeshRenderer _displayMeshRenderer;
    [SerializeField] private TextMeshPro _inputPasswordText;

    private string _typeCode = "";

    private CameraSwitch _cameraSwitch;

    private void Awake()
    {
        _cameraSwitch = FindObjectOfType<CameraSwitch>();

        if (_door != null)
            _openable = _door;

        if (_shelf != null)
            _openable = _shelf;

        _openable.Lock(this);
    }
}