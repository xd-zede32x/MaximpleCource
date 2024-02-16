using UnityEngine;

[RequireComponent(typeof(PlayerCamera))]
public class PlayerMover : MonoBehaviour
{
    private const string Vertical = "Vertical";
    private const string Horizontal = "Horizontal";

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);
        float distance = direction * _moveSpeed * Time.deltaTime;

        transform.Translate(distance * Vector3.forward);
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);

        transform.Rotate(rotation * _rotationSpeed * Time.deltaTime * Vector3.up);
    }
}