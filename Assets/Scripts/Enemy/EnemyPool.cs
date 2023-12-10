using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour,
        Listeners.IGameStartListener
    {
        [Header("Pool")]
        [SerializeField]
        private Transform container;

        [SerializeField]
        private GameObject prefab;

        [SerializeField]
        public int maxEnemies = 7;

        private readonly Queue<GameObject> enemyPool = new();

        public void OnGameStart()
        {
            for (var i = 0; i < maxEnemies; i++)
            {
                var enemy = Instantiate(prefab, container);
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