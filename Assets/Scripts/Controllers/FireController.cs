using UnityEngine;

namespace ShootEmUp
{
    class FireController : MonoBehaviour
    {
        [SerializeField]
        BulletSystem bulletSystem;

        [SerializeField]
        BulletConfig bulletConfig;

        [SerializeField]
        InputSystem input;

        [SerializeField]
        GameObject character;

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
