using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        [SerializeField]
        private WeaponComponent weaponComponent;

        //TODO This breaks game, DI needed
        private BulletSystem bulletSystem;

        [SerializeField]
        private EnemyMoveAgent moveAgent;

        [SerializeField]
        private float countdown;

        private GameObject target;
        private float currentTime;

        private bool readyForAttack;

        public void SetTarget(GameObject target)
        {
            this.target = target;
        }

        public void SetBulletSystem(BulletSystem bulletSystem)
        {
            if (this.bulletSystem == null)
                this.bulletSystem = bulletSystem;
        }

        public void SetReadyForAttack(bool ready)
        {
            readyForAttack = ready;
        }

        public void Reset()
        {
            currentTime = countdown;
        }

        private void FixedUpdate()
        {
            if (!readyForAttack)
            {
                return;
            }

            if (!target.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                return;
            }

            currentTime -= Time.fixedDeltaTime;
            if (currentTime <= 0)
            {
                Fire();
                currentTime += countdown;
            }
        }

        private void Fire()
        {
            var startPosition = weaponComponent.Position;
            var vector = (Vector2)target.transform.position - startPosition;
            var direction = vector.normalized;
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)PhysicsLayer.ENEMY_BULLET,
                color = Color.red,
                damage = 1,
                position = startPosition,
                velocity = direction * 2.0f
            });
        }
    }
}