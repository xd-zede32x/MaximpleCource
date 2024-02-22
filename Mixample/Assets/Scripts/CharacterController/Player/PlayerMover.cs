using UnityEngine;

namespace Doors
{
    public class PlayerMover : MonoBehaviour
    {
        private const string Vertical = nameof(Vertical);
        private const string Horizontal = nameof(Horizontal);

        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _rotationSpeed;

        private void Update()
        {
            PerformMovementAction();
            Rotate();
        }

        private void PerformMovementAction()
        {
            if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S)))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    Move(_runSpeed);

                else
                    Move(_walkSpeed);
            }
        }

        private void Move(float speed)
        {
            float direction = Input.GetAxis(Vertical);
            float distance = direction * speed * Time.deltaTime;

            transform.Translate(distance * Vector3.forward);
        }

        private void Rotate()
        {
            float rotation = Input.GetAxis(Horizontal);

            transform.Rotate(rotation * _rotationSpeed * Time.deltaTime * Vector3.up);
        }
    }
}