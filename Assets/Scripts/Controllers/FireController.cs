using UnityEngine;

namespace ShootEmUp
{
    public sealed class FireController : MonoBehaviour
    {
        [SerializeField]
        private BulletSystem bulletSystem;

        [SerializeField]
        private BulletConfig bulletConfig;

        [SerializeField]
        private InputSystem input;

        [SerializeField]
        private GameObject character;

        private void OnEnable()
        {
            input.OnFire += Fire;
        }

        private void OnDisable()
        {
            input.OnFire -= Fire;
        }

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
    }
}
