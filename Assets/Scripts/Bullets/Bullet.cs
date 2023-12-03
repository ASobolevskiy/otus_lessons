using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        [NonSerialized]
        public bool isPlayer;

        [NonSerialized]
        public int damage;

        [SerializeField]
        new Rigidbody2D rigidbody2D;

        [SerializeField]
        SpriteRenderer spriteRenderer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
            if (!collision.gameObject.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (isPlayer == team.IsPlayer)
            {
                return;
            }

            if (collision.gameObject.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(damage);
            }
        }

        public void SetVelocity(Vector2 velocity)
        {
            rigidbody2D.velocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }
    }
}