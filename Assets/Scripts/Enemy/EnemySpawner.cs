using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        public event Action<GameObject> OnEnemySpawned;

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

        [SerializeField]
        private float spawnDelayInSeconds = 1f;

        //TODO Link up with gamestate
        private readonly bool isGameRunning = true;

        private GameObject currentEnemy;

        private IEnumerator Start()
        {
            while (isGameRunning)
            {
                yield return new WaitForSeconds(spawnDelayInSeconds);
                if (enemyPool.HasNotSpawnedEnemies())
                    SpawnEnemy();
            }
        }

        public void SpawnEnemy()
        {
            currentEnemy = enemyPool.DequeueEnemy();
            currentEnemy.transform.SetParent(worldTransform);
            RestoreHpIfNeeded();
            SetSpawnPosition();
            SetAttackPosition();
            if (currentEnemy.TryGetComponent(out EnemyAttackAgent enemyAttackAgent))
            {
                enemyAttackAgent.SetTarget(character);
                enemyAttackAgent.SetBulletSystem(bulletSystem);
            }
            OnEnemySpawned?.Invoke(currentEnemy);
        }

        public void RemoveDestroyedEnemy(GameObject enemy) => enemyPool.EnqueueEnemy(enemy);

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