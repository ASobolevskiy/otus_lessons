using UnityEngine;

namespace ShootEmUp
{
    class EnemySpawner : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField] EnemyPositions enemyPositions;

        [SerializeField] EnemyPool enemyPool;

        [SerializeField] int maxSpawnedEnemies = 7;

        [SerializeField] Transform worldTransform;

        [SerializeField] GameObject character;

        GameObject currentEnemy;

        private void Awake() => enemyPool.FillEnemyQueue(maxSpawnedEnemies);
        public GameObject SpawnEnemy()
        {
            currentEnemy = enemyPool.DequeueEnemy();
            if(currentEnemy != null)
            {
                currentEnemy.transform.SetParent(worldTransform);
                RestoreHpIfNeeded();
                SetSpawnPosition();
                SetAttackPosition();
                currentEnemy.GetComponent<EnemyAttackAgent>().SetTarget(this.character);
            }
            return currentEnemy;
        }

        public void RemoveDestroyedEnemy(GameObject enemy) => enemyPool.EnqueueEnemy(enemy);

        void RestoreHpIfNeeded()
        {
            if(currentEnemy.TryGetComponent<HitPointsComponent>(out var hpComponent) && !hpComponent.IsHitPointsExists())
            {
                hpComponent.RestoreHpToMax();
            }
        }

        void SetSpawnPosition()
        {
            var spawnPosition = this.enemyPositions.RandomSpawnPosition();
            currentEnemy.transform.position = spawnPosition.position;
        }

        void SetAttackPosition()
        {
            var attackPosition = this.enemyPositions.RandomAttackPosition();
            currentEnemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
        }
    }
}