using System;
using UnityEngine;

namespace ShootEmUp.Factories
{
    [Serializable]
    public sealed class BulletFactory
    {
        [SerializeField]
        private Bullet prefab;

        public Bullet CreateBullet(Transform container)
        {
            return UnityEngine.Object.Instantiate(prefab, container);
        }
    }
}
