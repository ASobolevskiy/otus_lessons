using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveByRigidBodyComponent : MoveComponentBase
    {
        [SerializeField]
        new Rigidbody2D rigidbody2D;

        [SerializeField]
        float speed = 5.0f;

        Vector2 direction;

        public override void SetDirection(Vector2 direction)
        {
            this.direction = direction;
        }

        private void FixedUpdate()
        {
            var nextPosition = rigidbody2D.position + direction * speed * Time.fixedDeltaTime;
            rigidbody2D.MovePosition(nextPosition);
        }
    }
}