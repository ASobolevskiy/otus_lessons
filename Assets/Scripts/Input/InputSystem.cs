using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputSystem : MonoBehaviour
    {

        public event Action OnFire;
        public event Action<Vector2> OnMove;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFire?.Invoke();
            }
            OnMove?.Invoke(GetMovementDirection());
        }

        private Vector2 GetMovementDirection()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                return Vector2.left;
            return Input.GetKey(KeyCode.RightArrow) ? Vector2.right : Vector2.zero;
        }
    }
}