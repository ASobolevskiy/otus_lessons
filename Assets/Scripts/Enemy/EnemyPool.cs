using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Pool")]
        [SerializeField]
        Transform container;

        [SerializeField]
        GameObject prefab;

        [SerializeField]
        public int maxEnemies = 7;

        readonly Queue<GameObject> enemyPool = new();

        void Awake()
        {
            for (var i = 0; i < maxEnemies; i++)
            {
                var enemy = Instantiate(prefab, container);
                enemyPool.Enqueue(enemy);
            }
        }

        public GameObject DequeueEnemy() => enemyPool.Dequeue();

        public void EnqueueEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(container);
            enemyPool.Enqueue(enemy);
        }

        public bool HasNotSpawnedEnemies() => enemyPool.Any();
    }
}