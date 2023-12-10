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
                isPlayer = true,
                physicsLayer = (int)bulletConfig.physicsLayer,
                color = bulletConfig.color,
                damage = bulletConfig.damage,
                position = weapon.Position,
                velocity = weapon.Rotation * Vector3.up * bulletConfig.speed
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
