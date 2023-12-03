using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    class EnemySpawner : MonoBehaviour
    {
        public Action<GameObject> OnEnemySpawned;

        [Header("Spawn")]
        [SerializeField]
        EnemyPositions enemyPositions;

        [SerializeField]
        EnemyPool enemyPool;

        [SerializeField]
        Transform worldTransform;

        [SerializeField]
        GameObject character;

        [SerializeField]
        BulletSystem bulletSystem;

        [SerializeField]
        float spawnDelayInSeconds = 1f;

        //TODO Link up with gamestate
        readonly bool isGameRunning = true;

        GameObject currentEnemy;

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

        void RestoreHpIfNeeded()
        {
            if (currentEnemy.TryGetComponent<HitPointsComponent>(out var hpComponent) && !hpComponent.IsHitPointsExists())
            {
                hpComponent.RestoreHpToMax();
            }
        }

        void SetSpawnPosition()
        {
            var spawnPosition = enemyPositions.RandomSpawnPosition();
            currentEnemy.transform.position = spawnPosition.position;
        }

        void SetAttackPosition()
        {
            var attackPosition = enemyPositions.RandomAttackPosition();
            currentEnemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
        }
    }
}