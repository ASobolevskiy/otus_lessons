using ShootEmUp;
using ShootEmUp.DI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.Installers
{
    class BulletInstaller : MonoBehaviour,
        Providers.IServiceProvider,
        Providers.IInjectProvider
    {
        [SerializeField]
        private Bullet bullet;

        [SerializeField]
        private BulletConfig bulletConfig;

        [SerializeField]
        private BulletSystem bulletSystem;

        public IEnumerable<(Type, object)> ProvideServices()
        {
            yield return (typeof(BulletConfig), bulletConfig);
            yield return (typeof(BulletSystem), bulletSystem);
        }

        public void Inject(ServiceLocator serviceLocator)
        {

        }
    }
}
