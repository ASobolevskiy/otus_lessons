using ShootEmUp.Factories;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class EnemyPool : 
        Listeners.IGameStartListener
    {
        [SerializeField]
        private Transform container;

        [SerializeField]
        public int maxEnemies = 7;

        private readonly Queue<GameObject> enemyPool = new();
        private EnemyFactory enemyFactory;

        public void Construct(EnemyFactory enemyFactory)
        {
            this.enemyFactory = enemyFactory;
        }

        public void OnGameStart()
        {
            for (var i = 0; i < maxEnemies; i++)
            {
                var enemy = enemyFactory.CreateEnemy(container);
                enemyPool.Enqueue(enemy);
            }
        }

        public bool TryDequeueEnemy(out GameObject enemy) => enemyPool.TryDequeue(out enemy);

        public void EnqueueEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(container);
            enemyPool.Enqueue(enemy);
        }
    }
}