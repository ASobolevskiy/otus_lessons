using ShootEmUp.DI;
using ShootEmUp.Factories;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.Installers
{
    class EnemyInstaller : BaseInstaller
    {
        [SerializeField, Service(typeof(EnemyFactory))]
        private EnemyFactory enemyFactory;

        [SerializeField, Listener, Service(typeof(EnemyPool))]
        private EnemyPool enemyPool;

        [SerializeField, Service(typeof(EnemyPositions))]
        private EnemyPositions enemyPositions;

        [SerializeField, Listener]
        private EnemyCooldownSpawner enemyCooldownSpawner;

        [Service(typeof(EnemySpawner))]
        private EnemySpawner enemySpawner = new();

        [Listener]
        private EnemyManager enemyManager = new();
    }
}
