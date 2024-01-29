using ShootEmUp.DI;
using System;
using UnityEngine;

namespace ShootEmUp.Factories
{
    [Serializable]
    public sealed class EnemyFactory
    {
        [SerializeField]
        private GameObject prefab;

        private BulletSystem bulletSystem;
        private GameObject character;

        [Inject]
        public void Construct(BulletSystem bulletSystem, GameObject character)
        {
            Debug.Log($"{nameof(EnemyFactory)} Construct called!");
            this.bulletSystem = bulletSystem;
            this.character = character;
        }

        public GameObject CreateEnemy(Transform container)
        {
            GameObject enemy = UnityEngine.Object.Instantiate(prefab, container);
            if (enemy.TryGetComponent(out EnemyAttackAgent enemyAttackAgent))
            {
                enemyAttackAgent.SetBulletSystem(bulletSystem);
                enemyAttackAgent.SetTarget(character);
            }
            return enemy;
        }
    }
}