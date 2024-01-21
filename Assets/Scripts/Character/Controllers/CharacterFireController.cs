using ShootEmUp.DI;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterFireController : 
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        private InputSystem input;
        private GameObject character;
        private BulletSystem bulletSystem;
        private BulletConfig bulletConfig;

        public void Construct(GameObject character, BulletSystem bulletSystem, BulletConfig bulletConfig, InputSystem inputSystem)
        {
            Debug.Log($"{nameof(CharacterFireController)} Construct called!");
            this.character = character;
            this.bulletSystem = bulletSystem;
            this.bulletConfig = bulletConfig;
            input = inputSystem;
        }
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
