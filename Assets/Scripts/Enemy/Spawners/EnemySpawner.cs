using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        public event Action<GameObject> OnEnemySpawned;

        [SerializeField]
        private GameManager gameManager;

        [Header("Spawn")]
        [SerializeField]
        private EnemyPositions enemyPositions;

        [SerializeField]
        private EnemyPool enemyPool;

        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private GameObject character;

        [SerializeField]
        private BulletSystem bulletSystem;

        private GameObject currentEnemy;

        public void SpawnEnemy()
        {
            if(enemyPool.TryDequeueEnemy(out currentEnemy))
            {
                currentEnemy.transform.SetParent(worldTransform);
                RestoreHpIfNeeded();
                SetSpawnPosition();
                SetAttackPosition();
                if (currentEnemy.TryGetComponent(out EnemyAttackAgent enemyAttackAgent))
                {
                    enemyAttackAgent.SetTarget(character);
                    enemyAttackAgent.SetBulletSystem(bulletSystem);
                    gameManager.AddGameFixedUpdateListener(enemyAttackAgent);
                }
                if(currentEnemy.TryGetComponent(out EnemyMoveAgent enemyMoveAgent))
                {
                    gameManager.AddGameFixedUpdateListener(enemyMoveAgent);
                }
                if(currentEnemy.TryGetComponent(out MoveComponentBase moveComponent))
                {
                    gameManager.AddGameFixedUpdateListener(moveComponent);
                }
                OnEnemySpawned?.Invoke(currentEnemy);
            }
        }

        public void RemoveDestroyedEnemy(GameObject enemy)
        {
            if (currentEnemy.TryGetComponent(out EnemyAttackAgent enemyAttackAgent))
            {
                gameManager.RemoveGameFixedUpdateListener(enemyAttackAgent);
            }
            if (currentEnemy.TryGetComponent(out EnemyMoveAgent enemyMoveAgent))
            {
                gameManager.RemoveGameFixedUpdateListener(enemyMoveAgent);
            }
            if (currentEnemy.TryGetComponent(out MoveComponentBase moveComponent))
            {
                gameManager.RemoveGameFixedUpdateListener(moveComponent);
            }
            enemyPool.EnqueueEnemy(enemy);
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
    }
}