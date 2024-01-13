using UnityEngine;

namespace ShootEmUp
{
    public abstract class MoveComponentBase : MonoBehaviour, 
        Listeners.IGameListener
    {
        protected Vector2 moveDirection;

        public virtual void SetDirection(Vector2 direction)
        {
            moveDirection = direction;
        }
    }
}