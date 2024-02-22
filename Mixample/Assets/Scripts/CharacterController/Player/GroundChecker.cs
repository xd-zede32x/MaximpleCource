using UnityEngine;

namespace Doors
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private float _groundCheckDistance;

        public bool IsGround() => Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance);
    }
}   