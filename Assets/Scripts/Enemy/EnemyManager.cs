using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        EnemySpawner enemySpawner;

        private readonly HashSet<GameObject> activeEnemies = new();

        void Awake()
        {
            enemySpawner.OnEnemySpawned += HandleSpawnedEnemy;
        }

        private void HandleSpawnedEnemy(GameObject enemy)
        {
            if (activeEnemies.Add(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHpEmpty += OnDestroyed;
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHpEmpty -= OnDestroyed;
                enemySpawner.RemoveDestroyedEnemy(enemy);
            }
        }
    }
}