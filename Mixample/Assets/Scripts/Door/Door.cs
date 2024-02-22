using UnityEngine;

namespace Doors
{
    [RequireComponent(typeof(Animator))]
    public class Door : MonoBehaviour
    {
        private readonly int DoorOpen = Animator.StringToHash(nameof(DoorOpen));
        private readonly int DoorLose = Animator.StringToHash(nameof(DoorLose));

        private Animator _animator;

        private void Start() => _animator = GetComponent<Animator>();

        public void DoorOpining() => _animator.SetTrigger(DoorOpen);
        public void DoorClosing() => _animator.SetTrigger(DoorLose);
    }
}