using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputSystem : MonoBehaviour
    {

        public Action OnFire;
        public Action<Vector2> OnMove;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFire?.Invoke();
            }
            OnMove?.Invoke(GetMovementDirection());
        }

        Vector2 GetMovementDirection()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                return Vector2.left;
            return Input.GetKey(KeyCode.RightArrow) ? Vector2.right : Vector2.zero;
        }
    }
}