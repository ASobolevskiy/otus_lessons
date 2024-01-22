using ShootEmUp.DI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.Installers
{
    class EnemyInstaller : MonoBehaviour,
        Providers.IGameListenerProvider,
        Providers.IServiceProvider
    {
        [SerializeField]
        private EnemyPool enemyPool;

        public IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            yield return enemyPool;
        }

        public IEnumerable<(Type, object)> ProvideServices()
        {
            yield return (typeof(EnemyPool), enemyPool);
        }
    }
}
