using ShootEmUp.DI;
using ShootEmUp.Factories;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.Installers
{
    class EnemyInstaller : MonoBehaviour,
        Providers.IGameListenerProvider,
        Providers.IServiceProvider,
        Providers.IInjectProvider
    {
        [SerializeField]
        private EnemyFactory enemyFactory;

        [SerializeField]
        private EnemyPool enemyPool;

        [SerializeField]
        private EnemyPositions enemyPositions;

        [SerializeField]
        private EnemyCooldownSpawner enemyCooldownSpawner;

        private EnemySpawner enemySpawner = new();
        private EnemyManager enemyManager = new();

        public IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            yield return enemyPool;
            yield return enemyManager;
            yield return enemyCooldownSpawner;
        }

        public IEnumerable<(Type, object)> ProvideServices()
        {
            yield return (typeof(EnemyPool), enemyPool);
            yield return (typeof(EnemySpawner), enemySpawner);
        }

        public void Inject(ServiceLocator serviceLocator)
        {
            enemyFactory.Construct(serviceLocator.GetService<BulletSystem>(), serviceLocator.GetService<GameObject>());
            enemyPool.Construct(enemyFactory);
            enemySpawner.Construct(enemyPositions,
                                   enemyPool,
                                   serviceLocator.GetService<BulletSystem>(),
                                   serviceLocator.GetService<GameObject>(),
                                   serviceLocator.GetService<GameManager>(),
                                   serviceLocator.GetService<Transform>());
            enemyManager.Construct(enemySpawner);
            enemyCooldownSpawner.Construct(enemySpawner);
        }
    }
}
