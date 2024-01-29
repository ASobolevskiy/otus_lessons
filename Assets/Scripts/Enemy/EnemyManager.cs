using ShootEmUp.DI;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager :
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        private EnemySpawner enemySpawner;
        private readonly HashSet<GameObject> activeEnemies = new();

        [Inject]
        public void Construct(EnemySpawner enemySpawner)
        {
            Debug.Log($"{nameof(EnemyManager)} Construct called");
            this.enemySpawner = enemySpawner;
        }
        private void HandleSpawnedEnemy(GameObject enemy)
        {
            if (activeEnemies.Add(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHpEmpty += OnDestroyed;
                if (enemy.TryGetComponent(out EnemyDestinationReachedController enemyDestinationReachedController))
                {
                    enemyDestinationReachedController.Activate();
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHpEmpty -= OnDestroyed;
                if (enemy.TryGetComponent(out EnemyDestinationReachedController enemyDestinationReachedController))
                {
                    enemyDestinationReachedController.Deactivate();
                }
                enemySpawner.RemoveDestroyedEnemy(enemy);
            }
        }

        public void OnGameStart()
        {
            enemySpawner.OnEnemySpawned += HandleSpawnedEnemy;
        }

        public void OnGameFinish()
        {
            enemySpawner.OnEnemySpawned -= HandleSpawnedEnemy;
        }
    }
}