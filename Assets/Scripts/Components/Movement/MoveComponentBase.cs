using UnityEngine;

namespace ShootEmUp
{
    public abstract class MoveComponentBase : MonoBehaviour, 
        Listeners.IGameFixedUpdateListener
    {
        public abstract void OnFixedUpdate(float fixedDeltaTime);

        public abstract void SetDirection(Vector2 direction);
    }
}