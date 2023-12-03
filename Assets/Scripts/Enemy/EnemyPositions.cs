using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField]
        Transform[] spawnPositions;

        [SerializeField]
        Transform[] attackPositions;

        public Transform RandomSpawnPosition()
        {
            return RandomTransform(spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return RandomTransform(attackPositions);
        }

        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}