using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public Action OnDestinationReached;

        [SerializeField]
        MoveComponentBase moveComponent;

        [SerializeField]
        float moveThreshold = 0.25f;

        Vector2 destination;
        bool isReached;


        public void SetDestination(Vector2 endPoint)
        {
            destination = endPoint;
            isReached = false;
        }

        private void FixedUpdate()
        {
            if (isReached)
            {
                return;
            }

            var vector = destination - (Vector2)transform.position;
            if (vector.magnitude <= moveThreshold)
            {
                isReached = true;
                moveComponent.SetDirection(Vector2.zero);
                OnDestinationReached?.Invoke();
                return;
            }

            var direction = vector.normalized;
            moveComponent.SetDirection(direction);
        }
    }
}