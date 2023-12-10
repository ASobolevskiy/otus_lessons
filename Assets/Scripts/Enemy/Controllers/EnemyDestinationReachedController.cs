using ShootEmUp;
using UnityEngine;

namespace Assets.Scripts.Enemy.Controllers
{
    public sealed class EnemyDestinationReachedController : MonoBehaviour
    {
        [SerializeField]
        private EnemyMoveAgent moveAgent;

        [SerializeField]
        private EnemyAttackAgent attackAgent;
        private void Awake()
        {
            moveAgent.OnDestinationReached += HandleDestinationReached;
        }

        private void HandleDestinationReached()
        {
            attackAgent.SetReadyForAttack(true);
        }
    }
}
