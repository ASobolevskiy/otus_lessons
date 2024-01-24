using ShootEmUp.DI;
using ShootEmUp.Factories;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.Installers
{
    class BulletInstaller : MonoBehaviour,
        Providers.IGameListenerProvider,
        Providers.IServiceProvider,
        Providers.IInjectProvider
    {
        [SerializeField]
        private BulletConfig bulletConfig;

        [SerializeField]
        private BulletPool bulletPool;

        [SerializeField]
        private BulletFactory bulletFactory;

        private BulletSystem bulletSystem = new();

        public IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            yield return bulletPool;
        }

        public IEnumerable<(Type, object)> ProvideServices()
        {
            yield return (typeof(BulletConfig), bulletConfig);
            yield return (typeof(BulletPool), bulletPool);
            yield return (typeof(BulletSystem), bulletSystem);
        }

        public void Inject(ServiceLocator serviceLocator)
        {
            bulletPool.Construct(serviceLocator.GetService<Transform>(), bulletFactory);
            bulletSystem.Construct(serviceLocator.GetService<LevelBounds>(), bulletPool);
        }
    }
}
