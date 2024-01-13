using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveByRigidBodyComponent : MoveComponentBase,
        Listeners.IGameFixedUpdateListener
    {
        [SerializeField]
        private new Rigidbody2D rigidbody2D;

        [SerializeField]
        private float speed = 5.0f;

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            var nextPosition = rigidbody2D.position + (speed * fixedDeltaTime * moveDirection);
            rigidbody2D.MovePosition(nextPosition);
        }
    }
}