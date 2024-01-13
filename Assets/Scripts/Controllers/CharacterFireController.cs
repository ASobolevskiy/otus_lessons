using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterFireController : MonoBehaviour, 
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private BulletSystem bulletSystem;

        [SerializeField]
        private BulletConfig bulletConfig;

        [SerializeField]
        private InputSystem input;

        [SerializeField]
        private GameObject character;

        private void Fire()
        {
            var weapon = character.GetComponent<WeaponComponent>();
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                IsPlayer = true,
                PhysicsLayer = (int)bulletConfig.physicsLayer,
                Color = bulletConfig.color,
                Damage = bulletConfig.damage,
                Position = weapon.Position,
                Velocity = weapon.Rotation * Vector3.up * bulletConfig.speed
            });

        }

        public void OnGameStart()
        {
            input.OnFire += Fire;
        }

        public void OnGameFinish()
        {
            input.OnFire -= Fire;
        }
    }
}
