using ShootEmUp.DI;
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

        private EnemyPool enemyPool;

        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private GameObject character;

        [SerializeField]
        private BulletSystem bulletSystem;

        private GameObject currentEnemy;

        [Inject]
        public void Construct(EnemyPool enemyPool)
        {
            Debug.Log($"{nameof(EnemySpawner)} Construct called!");
            this.enemyPool = enemyPool;
        }
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
                    gameManager.AddGameListener(enemyAttackAgent);
                }
                if(currentEnemy.TryGetComponent(out EnemyMoveAgent enemyMoveAgent))
                {
                    gameManager.AddGameListener(enemyMoveAgent);
                }
                if(currentEnemy.TryGetComponent(out MoveComponentBase moveComponent))
                {
                    gameManager.AddGameListener(moveComponent);
                }
                OnEnemySpawned?.Invoke(currentEnemy);
            }
        }

        public void RemoveDestroyedEnemy(GameObject enemy)
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