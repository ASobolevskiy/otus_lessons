using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour,
        Listeners.IGameFixedUpdateListener
    {
        [SerializeField]
        private WeaponComponent weaponComponent;

        [SerializeField]
        private float countdown;

        private BulletSystem bulletSystem;


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

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (!readyForAttack)
            {
                return;
            }

            if (!target.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                return;
            }

            currentTime -= fixedDeltaTime;
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
                IsPlayer = false,
                PhysicsLayer = (int)PhysicsLayer.ENEMY_BULLET,
                Color = Color.red,
                Damage = 1,
                Position = startPosition,
                Velocity = direction * 2.0f
            });
        }

    }
}