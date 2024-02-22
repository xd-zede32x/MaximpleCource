using UnityEngine;

namespace Shelfs
{
    [RequireComponent(typeof(Animator))]
    public class Shelf : MonoBehaviour
    {
        private readonly int ShelfOpen = Animator.StringToHash(nameof(ShelfOpen));
        private readonly int ShelfClose = Animator.StringToHash(nameof(ShelfClose));
        
        private Animator _animator;

        private void Start() => _animator = GetComponent<Animator>();

        public void ShelfOpining() => _animator.SetTrigger(ShelfOpen);
        public void ShelfClosing() => _animator.SetTrigger(ShelfClose);
    }
}   