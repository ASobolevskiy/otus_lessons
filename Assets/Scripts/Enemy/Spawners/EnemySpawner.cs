using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner
    {
        public event Action<GameObject> OnEnemySpawned;

        private Transform worldTransform;
        private EnemyPositions enemyPositions;
        private GameManager gameManager;
        private GameObject character;
        private EnemyPool enemyPool;
        private BulletSystem bulletSystem;
        private GameObject currentEnemy;

        public void Construct(EnemyPositions enemyPositions, EnemyPool enemyPool, BulletSystem bulletSystem, GameObject character, GameManager gameManager, Transform worldTransform)
        {
            Debug.Log($"{nameof(EnemySpawner)} Construct called!");
            this.enemyPositions = enemyPositions;
            this.enemyPool = enemyPool;
            this.bulletSystem = bulletSystem;
            this.character = character;
            this.gameManager = gameManager;
            this.worldTransform = worldTransform;
        }
        public void SpawnEnemy()
        {
            if(enemyPool.TryDequeueEnemy(out currentEnemy))
            {
                currentEnemy.transform.SetParent(worldTransform);
                RestoreHpIfNeeded();
                SetSpawnPosition();
                SetAttackPosition();
                RegisterListeners();
                OnEnemySpawned?.Invoke(currentEnemy);
            }
        }

        private void RestoreHpIfNeeded()
        {
            if (currentEnemy.TryGetComponent<HitPointsComponent>(out var hpComponent) && !hpComponent.IsHitPointsExists())
            {
                hpComponent.RestoreHpToMax();
            }
        }

        private void SetSpawnPosition()
        {
            var spawnPosition = enemyPositions.RandomSpawnPosition();
            currentEnemy.transform.position = spawnPosition.position;
        }

        private void SetAttackPosition()
        {
            var attackPosition = enemyPositions.RandomAttackPosition();
            currentEnemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
        }

        private void RegisterListeners()
        {
            if (currentEnemy.TryGetComponent(out EnemyAttackAgent enemyAttackAgent))
            {
                gameManager.AddGameListener(enemyAttackAgent);
            }
            if (currentEnemy.TryGetComponent(out EnemyMoveAgent enemyMoveAgent))
            {
                gameManager.AddGameListener(enemyMoveAgent);
            }
            if (currentEnemy.TryGetComponent(out MoveComponentBase moveComponent))
            {
                gameManager.AddGameListener(moveComponent);
            }
        }

        public void RemoveDestroyedEnemy(GameObject enemy)
        {
            UnregisterListeners(enemy);
            enemyPool.EnqueueEnemy(enemy);
        }

        private void UnregisterListeners(GameObject enemy)
        {
            if (enemy.TryGetComponent(out EnemyAttackAgent enemyAttackAgent))
            {
                gameManager.RemoveGameListener(enemyAttackAgent);
            }
            if (enemy.TryGetComponent(out EnemyMoveAgent enemyMoveAgent))
            {
                gameManager.RemoveGameListener(enemyMoveAgent);
            }
            if (enemy.TryGetComponent(out MoveComponentBase moveComponent))
            {
                gameManager.RemoveGameListener(moveComponent);
            }
        }
    }
}