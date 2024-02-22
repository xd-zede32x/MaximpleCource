using UnityEngine;

namespace Doors
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(GroundChecker))]
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;

        private Rigidbody _rigidbody;
        private GroundChecker _groundChecker;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _groundChecker = GetComponent<GroundChecker>();
        }

        private void Update() => Jump();

        private void Jump()
        {
            bool isJump = _groundChecker.IsGround() && Input.GetKeyDown(KeyCode.Space);

            if (isJump)
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}   