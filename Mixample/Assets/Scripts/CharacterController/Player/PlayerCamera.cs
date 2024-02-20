using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private float _sensitivity;
    [SerializeField] private Transform _cameraTransform;

    private void Start() => CursorVisible(false);
    private void Update() => CameraRotation();

    private void CameraRotation()
    {
        float mouseX, mouseY;
        InputCamera(out mouseX, out mouseY);

        float newAngleX = _cameraTransform.rotation.eulerAngles.x - mouseY * _sensitivity;

        if (newAngleX > 180)
            newAngleX -= 360;

        CameraRotation(mouseX, newAngleX);
    }

    private void InputCamera(out float mouseX, out float mouseY)
    {
        mouseX = Input.GetAxis(MouseX);
        mouseY = Input.GetAxis(MouseY);
    }

    private void CameraRotation(float mouseX, float newAngleX)
    {
        newAngleX = Mathf.Clamp(newAngleX, -80, 80);
        _cameraTransform.rotation = Quaternion.Euler(newAngleX, _cameraTransform.rotation.eulerAngles.y, _cameraTransform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseX * _sensitivity, transform.rotation.eulerAngles.z);
    }

    private static void CursorVisible(bool isActive)
    {
        Cursor.visible = isActive;
        Cursor.lockState = CursorLockMode.Locked;
    }
}