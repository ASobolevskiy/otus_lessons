using ShootEmUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy.Controllers
{
    class EnemyDestinationReachedController : MonoBehaviour
    {
        [SerializeField]
        EnemyMoveAgent moveAgent;

        [SerializeField]
        EnemyAttackAgent attackAgent;
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
