using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Pool")]
        [SerializeField]
        private Transform container;

        [SerializeField]
        private GameObject prefab;

        private readonly Queue<GameObject> enemyPool = new();
        
        public void FillEnemyQueue(int maxEnemies)
        {
            for (var i = 0; i < maxEnemies; i++)
            {
                var enemy = Instantiate(this.prefab, this.container);
                this.enemyPool.Enqueue(enemy);
            }
        }

        public GameObject DequeueEnemy() => enemyPool.TryDequeue(out var enemy) ? enemy : null;

        public void EnqueueEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(this.container);
            this.enemyPool.Enqueue(enemy);
        }
    }
}